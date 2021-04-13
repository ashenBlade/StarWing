using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using System.Windows.Input;

namespace StarWing.Framework.Input
{
    public readonly struct KeyboardStatus
    {
        private readonly List<Keys> _pressed;
        private readonly Keys _justPressed;
        public bool Shift { get;  }
        public bool Alt { get; }
        public bool Control { get; }

        public KeyboardStatus(List<Keys> pressed, Keys justPressed, bool alt, bool ctrl, bool shift)
        {
            _justPressed = justPressed;
            _pressed = pressed;
            Shift = shift;
            Alt = alt;
            Control = ctrl;
        }


        public bool IsKeyDown(Keys key) =>
            _pressed.Contains(key) ||
            (key == Keys.Shift && Shift) ||
            (key == Keys.Alt && Alt) ||
            (key == Keys.Control && Control);

        public bool IsKeyUp(Keys key) =>
            !IsKeyDown(key);

        public bool IsKeyJustPressed(Keys key) =>
            key == _justPressed;

        public Keys JustPressed =>
            _justPressed;

        public Keys[] Pressed =>
            _pressed.ToArray();
    }
}