using StarWing.Framework;
using System.Drawing;

namespace StarWing
{
    public class Star : IBackground
    {
        public void Render(Graphics graphics)
        {
            graphics.DrawEllipse(Color, Position.X, Position.Y, Height, Width);
            graphics.FillEllipse(Brushes.Ivory, Position.X, Position.Y, Height, Width);
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction;
            if (Position.X < 0)
            {
                RandomSet();
            }
        }

        private int Height;
        private int Width;
        private Vector2D Position;
        private Vector2D Direction;
        private Pen Color;

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
            RandomSet();
        }

        public void RandomSet()
        {
            Position = new Vector2D(OuterSpace.GetRandomNumber(OuterSpace.Width, OuterSpace.Width + 300),
                OuterSpace.GetRandomNumber(0, OuterSpace.Height));
            Color = Pens.Ivory;
        }

    }
}