using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class OuterSpace: IBackground
    {

        public int Height;
        public int Width;
        
        private Star[] stars;
        
        public Random rnd = new Random();

        public int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min,max);
        }
        
        public OuterSpace()
        {
            Height = Game.GameWindow.WindowSize.Height;
            Width = Game.GameWindow.WindowSize.Width;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Vector2D(-rnd.Next(1, 10), 0));
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
                star.Update(gameTime);
            }
        }
    }
}