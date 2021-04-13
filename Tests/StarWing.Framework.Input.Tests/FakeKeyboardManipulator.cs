using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StarWing.Framework.Input;

namespace Tests.StarWing.Framework.Input.Tests
{
    public class FakeKeyboardManipulator : IKeyboardManipulator
    {
        private readonly List<Keys> _pressed = new();

        public IReadOnlyList<Keys> Pressed =>
            _pressed;

        public void Press(Keys key)
        {
            _pressed.Add(key);
            KeyDown?.Invoke(this, new KeyEventArgs(key));
        }

        public void Release(Keys key)
        {
            _pressed.Remove(key);
            KeyUp?.Invoke(this, new KeyEventArgs(key));
        }

        public void ReleaseAll()
        {
            _pressed.ForEach(key => KeyUp?.Invoke(this, new KeyEventArgs(key)));
            _pressed.Clear();
        }

        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;
    }
}