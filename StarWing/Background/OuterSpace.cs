using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class OuterSpace: IBackground
    {
        // размеры окна
        public static int Width;
        public static int Height;

        private static Star[] stars;

        public static Random rnd = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min,max);
        }

        static public void Init(int width, int height)
        {
            OuterSpace.Width = width;
            OuterSpace.Height = height;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Vector2D(-rnd.Next(1, 10), 0));
            }
        }
        
        public void Render(Graphics graphics)
        {
            graphics.Clear(Color.MidnightBlue);
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