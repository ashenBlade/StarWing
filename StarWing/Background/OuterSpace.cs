using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class OuterSpace: IBackground
    {

        private int Height;
        private int Width;
        
        private Star[] stars;
        
        private Random rnd = new Random();

        private int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min,max);
        }
        
        public OuterSpace(int height, int width)
        {
            Height = height;
            Width = width;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Vector2D(-rnd.Next(1, 10), 0));
                RandomSet(stars[i]);
            }
        }
        
        public void Render(Graphics graphics)
        {
            graphics.Clear(Color.Black);
            foreach (var star in stars)
            {
                star.Render(graphics);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var star in stars)
            {
                star.Position += star.Direction*gameTime.SinceLastUpdate.Milliseconds*(float)0.1;
                if (star.Position.X < 0)
                {
                    RandomSet(star);
                }
            }
        }
        
        private void RandomSet(Star star)
        {
            star.Position = new Vector2D(GetRandomNumber(0,this.Width + 300),
                GetRandomNumber(0, this.Height));
            star.Color = Pens.Ivory;
        }
    }
}