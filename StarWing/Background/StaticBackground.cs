using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class StaticBackground : IBackground
    {
        private Image _background;
        private Size _bounds;

        public StaticBackground(Size bounds, Image background)
        {
            _background = background ?? throw new ArgumentNullException(nameof(background));
            _bounds = bounds;
        }
        public void Render(Graphics graphics)
        {
            graphics.DrawImage(_background, new Rectangle(Point.Empty, _bounds));
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}