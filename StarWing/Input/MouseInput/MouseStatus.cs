using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public readonly struct MouseStatus
    {
        public Point Position { get; }

        private MouseButtons _justPressed { get; }
        private List<MouseButtons> _pressed { get; }

        public MouseStatus(Point position, List<MouseButtons> pressed, MouseButtons justPressed)
        {
            Position = position;
            _pressed = pressed;
            _justPressed = justPressed;
        }

        public MouseButtons[] Pressed =>
            _pressed.ToArray();

        public MouseButtons JustPressed =>
            _justPressed;

        public bool IsButtonJustPressed(MouseButtons button) =>
            _justPressed == button;

        public bool IsButtonPressed(MouseButtons button) =>
            _pressed.Contains(button);
    }
}