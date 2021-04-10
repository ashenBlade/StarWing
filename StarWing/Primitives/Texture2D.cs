using System;
using System.Drawing;

namespace StarWing.Framework.Primitives
{
    public class Texture2D
    {
        public Texture2D(Image sprite, float scale)
        {
            Sprite = sprite;
            Scale = scale;
        }

        public float Scale { get; private set; }
        public Image Sprite { get; private set; }
    }
}