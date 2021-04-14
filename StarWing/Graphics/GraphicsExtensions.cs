using System.Drawing;
using System.Drawing.Drawing2D;

namespace StarWing.Framework
{
    public static class GraphicsExtensions
    {
        public static void DrawSprite(this Graphics graphics, Sprite sprite, Vector2D position)
        {
            var spriteLocationX = position.X - sprite.Center.X;
            var spriteLocationY = -position.Y + graphics.VisibleClipBounds.Size.Height - sprite.Center.Y;

            var spriteRect = new Rectangle(new Point((int)spriteLocationX, (int)spriteLocationY), sprite.Size);
            if (!graphics.IsVisible(spriteRect))
            {
                return;
            }
            float dx = spriteLocationX + (float) sprite.Width / 2;
            float dy = spriteLocationY + (float) sprite.Height / 2;

            // Shift center of graphics to this position
            graphics.TranslateTransform(dx, dy, MatrixOrder.Prepend);

            // Do not do unnecessary work
            if (sprite.Rotation != 0)
                graphics.RotateTransform(sprite.Rotation);

            // Draw sprite
            graphics.TranslateTransform(-dx, -dy, MatrixOrder.Prepend);

            graphics.DrawImage(sprite.Image, spriteRect);
        }
    }
}