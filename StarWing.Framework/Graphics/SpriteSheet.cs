using System;
using System.Drawing;

namespace StarWing.Framework
{
    public class SpriteSheet : IDisposable
    {
        public Image Image { get; }

        public bool Disposed { get; private set; }

        public int Width =>
            Image.Width;

        public int Height =>
            Image.Height;

        public SpriteSheet(Image image)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image), "Image can not be null");
            Disposed = false;
        }

        public Sprite GetSprite(int x, int y, int width, int height, float angle = 0)
        {
            return GetSprite(new Rectangle(x, y, width, height), angle);
        }
        public Sprite GetSprite(Rectangle spritePosition, float angle = 0)
        {
            var bitmap = new Bitmap(spritePosition.Width, spritePosition.Height);
            var destRect = new Rectangle(Point.Empty, bitmap.Size);
            using var graphics = System.Drawing.Graphics.FromImage(bitmap);
            graphics.DrawImage(Image, destRect, spritePosition, GraphicsUnit.Pixel); // Copying image
            return new Sprite(bitmap, angle);
        }

        public void Dispose()
        {
            Image?.Dispose();
            Disposed = true;
        }
    }
}