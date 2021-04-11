using System;
using System.Drawing;

namespace StarWing.Framework.Primitives
{
    public class Texture2D
    {
        public Texture2D(Image image, float scale)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Scale = scale > 0
                        ? scale
                        : throw new ArgumentOutOfRangeException(nameof(scale), "Scale can not be negative");
        }

        public float Scale { get; private set; }
        public Image Image { get; private set; }
    }
}