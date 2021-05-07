using System;
using System.Drawing;

namespace StarWing.Framework
{
    public class Sprite : IDisposable
    {
        public static readonly Sprite Empty = new Sprite(new Bitmap(0, 0));

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
            return new Sprite(spriteImage, height, width, rotation);
        }
        public Sprite(Image image) : this(image, image.Height, image.Width, 0.0f, 1.0f)
        { }
        public Sprite(Image image, Size size) : this(image, size.Height, size.Width)
        { }
        public Sprite(Image image, int height, int width) : this(image, height, width, 0.0f, 1.0f)
        { }
        public Sprite(Image image, int height, int width, float rotation) : this(image, height, width, rotation, 1.0f)
        { }
        public Sprite(Image image, int height, int width, float rotation, float scale)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Rotation = rotation;
            Disposed = false;
            Height = height;
            Width = width;
            Scale = scale;
        }

        /// <summary>
        /// Represents part of <see cref="Image"/> that would be rendered
        /// </summary>
        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public Point Center =>
            new Point(Width / 2, Height / 2);

        public float Rotation { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Scale { get; set; }
        public Image Image { get; }

        public void Dispose()
        {
            Image?.Dispose();
            Disposed = true;
        }
    }
}