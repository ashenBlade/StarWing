using System;
using System.Drawing;

namespace StarWing.Framework
{
    public static class GraphicsExtensions
    {
        public static void DrawSprite(this Graphics graphics, Sprite sprite, Vector2D position)
        {
            if (sprite.Image == null)
            {
                throw new ArgumentNullException(nameof(sprite));
            }
            graphics.DrawImage(sprite.Image, new Rectangle(position, sprite.Size));
        }
    }
}