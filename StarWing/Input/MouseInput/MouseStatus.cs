using System.Drawing;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public readonly struct MouseStatus
    {
        public Point Position { get; }

        private int _pressed { get; }

        public MouseStatus(Point position, int pressed)
        {
            Position = position;
            _pressed = pressed;
        }

        public bool IsButtonPressed(MouseButtons button)
        {
            return (_pressed & ( int ) button) == ( int ) button;
        }
    }
}