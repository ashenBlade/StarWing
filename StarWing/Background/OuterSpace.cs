using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class OuterSpace: IBackground
    {
        private static OuterSpace _current;

        public static int Height;
        public static int Width;

        public OuterSpace(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public static void StartNew(OuterSpace outerSpace)
        {
            _current = outerSpace ?? throw new ArgumentNullException(nameof(outerSpace));
        }
        public static IBackground Current =>
            _current;

        private static Star[] stars;

        public static Random rnd = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min,max);
        }
        public void Init(int height, int width)
        {
            OuterSpace.Height = height;
            OuterSpace.Width = width;
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