using StarWing.Framework;
using System.Drawing;

namespace StarWing
{
    public class Star
    {
        public void Render(Graphics graphics)
        {
            graphics.DrawEllipse(Color, Position.X, Position.Y, Height, Width);
            graphics.FillEllipse(Brushes.Ivory, Position.X, Position.Y, Height, Width);
        }
        
        

        private int Height;
        private int Width;
        public Vector2D Position;
        public Vector2D Direction;
        public Pen Color;
        
        
        
        public Star(Vector2D position, Vector2D direction, int size, Pen color)
        {
            Position = position;
            Direction = direction;
            Height = size;
            Width = size;
            Color = color;
        }

        public Star(Vector2D direction)
        {
            Direction = direction;
            Height = 1;
            Width = 1;
        }
        
    }
}