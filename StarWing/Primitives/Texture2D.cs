using System;
using System.Drawing;

namespace StarWing.Framework.Primitives
{
    public class Texture2D
    {
        public Texture2D(Image image, float scale, int width, int height)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Scale = scale >= 0
                        ? scale
                        : throw new ArgumentOutOfRangeException(nameof(scale), "Scale can not be negative");
            Width = width >= 0
                        ? width
                        : throw new ArgumentOutOfRangeException(nameof(width), "Width can not be negative");
            Height = height >= 0
                         ? height
                         : throw new ArgumentOutOfRangeException(nameof(height), "Height can not be negative");
        }

        public int Width { get; }
        public int Height { get; }
        public float Scale { get; }
        public Image Image { get; }
    }
}