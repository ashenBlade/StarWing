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
        private readonly HashSet<Keys> _pressed;

        /// <param name="keys">Keys that are being pressed currently</param>
        public KeyboardStatus(HashSet<Keys> keys)
        {
            _pressed = keys;
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
    }
}