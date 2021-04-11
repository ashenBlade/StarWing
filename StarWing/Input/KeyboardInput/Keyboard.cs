using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // Keys are being currently pressed
        private readonly HashSet<Keys> _pressed;

        public KeyboardStatus Status =>
            new KeyboardStatus(_pressed);

        /// <param name="form">Form to listen input from</param>
        public Keyboard(Form form)
        {
            _pressed = new HashSet<Keys>();

            form.KeyDown += UpdateOnKeyDown;
            form.KeyUp += UpdateOnKeyUp;
        }

        private void UpdateOnKeyUp(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _pressed.Remove(key);
        }
        private void UpdateOnKeyDown(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _pressed.Add(key);
        }
    }
}