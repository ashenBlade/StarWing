using System;
using StarWing.Framework;
using System.Drawing;

namespace StarWing
{
    public class Star
    {
        private Random rnd = new Random();
        public void Render(Graphics graphics)
        { 
            graphics.DrawEllipse(new Pen(Color), Position.X, Position.Y, Height, Width);
            graphics.FillEllipse(new SolidBrush(Color), Position.X, Position.Y, Height, Width);
        }
        

        private int Height;
        private int Width;
        public Vector2D Position;
        public Vector2D Direction;
        public Color Color;
        
        
        
        public Star(Vector2D position, Vector2D direction, int size, Color color)
        {
            Position = position;
            Direction = direction;
            Height = size;
            Width = size;
            Color = color;
        }

        public Star(Vector2D direction)
        {
            Color = Color.FromArgb(rnd.Next(100,150), rnd.Next(100,150),rnd.Next(100,150));
            Direction = direction;
            Height = 2;
            Width = 2;
        }
        
    }
}