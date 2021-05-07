using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StarWing.Framework
{
    public static class GraphicsExtensions
    {
        public static void DrawSprite(this Graphics graphics, Sprite sprite, Vector2D position)
        {
            if (sprite.Image == null)
                return;
            graphics.DrawImage(sprite.Image, new RectangleF(position, sprite.Size));
        }
    }
}