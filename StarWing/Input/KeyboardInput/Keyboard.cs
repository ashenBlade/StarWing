using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // Keys are being currently pressed
        private readonly HashSet<Keys> _pressed = new HashSet<Keys>();

        public KeyboardStatus Status =>
            new KeyboardStatus(_pressed);

        /// <param name="form">Form to listen input from</param>
        public Keyboard(Form form)
        {
            SubscribeToForm(form);
        }

        private void SubscribeToForm(Form form)
        {
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