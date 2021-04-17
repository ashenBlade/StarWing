using System;
using System.Drawing;
using System.Numerics;

namespace StarWing.Framework
{
    public class Sprite : IDisposable
    {
        public static Sprite FromSpriteSheet(SpriteSheet sheet, Point start, Size size, float rotation = 0)
        {
            return FromSpriteSheet(sheet, start.X, start.Y, size.Width, size.Height, rotation);
        }

        public bool Disposed { get; private set; }

        public static Sprite FromSpriteSheet(SpriteSheet sheet, int x, int y, int width, int height, float rotation = 0)
        {
            var spriteImage = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(spriteImage);
            graphics.DrawImage(sheet.Image, x, y, width, height);
            return new Sprite(spriteImage, rotation);
        }
        public Sprite(Image image) : this(image, 0)
        { }
        public Sprite(Image image, float rotation)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Rotation = rotation;
            Disposed = false;
        }

        /// <summary>
        /// Represents part of <see cref="Image"/> that would be rendered
        /// </summary>
        public Size Size =>
            new Size(Width, Height);

        public Point Center =>
            new Point(Width / 2, Height / 2);

        public float Rotation { get; set; }

        public int Width =>
            Image.Width;

        public int Height =>
            Image.Height;
        public Image Image { get; }
        public void Dispose()
        {
            Image?.Dispose();
            Disposed = true;
        }
    }
}