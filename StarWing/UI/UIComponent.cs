using System.Collections.Generic;
using System.Drawing;
using Accessibility;
using StarWing.Framework;

namespace StarWing.UI
{
    public class UIComponent
    {
        public Vector2D Position
        {
            get => Bounds.Location;
            set
            {
                _bounds.Location = value;
            }
        }

        private Rectangle _bounds;
        public Rectangle Bounds
        {
            get => _bounds;
            set
            {
                _bounds = value;
            }
        }
        public Color Background { get; set; } = Color.Transparent;

        public virtual void Update(GameTime gametime, Input input)
        { }

        public virtual void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Background), Bounds);
        }
    }
}