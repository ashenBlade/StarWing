using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public readonly struct KeyboardStatus
    {
        private readonly IReadOnlyCollection<Keys> _pressed;
        private readonly Keys _justPressed;

        public bool Alt =>
            _pressed.Contains(Keys.Menu);

        public bool Control =>
            _pressed.Contains(Keys.ControlKey);

        public bool Shift =>
            _pressed.Contains(Keys.ShiftKey);

        public KeyboardStatus(IReadOnlyCollection<Keys> pressed, Keys justPressed)
        {
            _justPressed = justPressed;
            _pressed = pressed;
        }


        public bool IsKeyDown(Keys key)
        {
            // Modifier keys treats different
            if (key == Keys.Alt)
                return Alt;
            if (key == Keys.Shift)
                return Shift;
            if (key == Keys.Control)
                return Control;

            return _pressed.Contains(key);
        }
        public bool IsKeyUp(Keys key) =>
            !IsKeyDown(key);

        public bool IsKeyJustPressed(Keys key) =>
            key == _justPressed;

        public Keys JustPressed =>
            _justPressed;

        public IReadOnlyCollection<Keys> Pressed =>
            _pressed;
    }
}