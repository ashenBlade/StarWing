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

        public KeyboardStatus(List<Keys> pressed, Keys justPressed)
        {
            _justPressed = justPressed;
            _pressed = pressed;
        }

        public bool Shift =>
            _pressed.Contains(Keys.Shift);

        public bool Control =>
            _pressed.Contains(Keys.Control);

        public bool Alt =>
            _pressed.Contains(Keys.Alt);

        public bool IsKeyDown(Keys key)
        {
            return _pressed.Contains(key);
        }

        public bool IsKeyUp(Keys key)
        {
            return !IsKeyDown(key);
        }

        public bool IsKeyJustPressed(Keys key)
        {
            return key == _justPressed;
        }

        public Keys JustPressed =>
            _justPressed;

        public Keys[] Pressed =>
            _pressed.ToArray();
    }
}