using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // It would be better to store it in integers
        private readonly List<Keys> _pressed = new();
        private Keys _toAdd = Keys.None;

        public KeyboardStatus Status {
            get
            {
                var key = _toAdd;
                _toAdd = Keys.None;
                return new KeyboardStatus(_pressed, key);
            }
        }

        /// <param name="form">Form to listen input from</param>
        public Keyboard(IPressableManipulator<KeyEventArgs> form)
        {
            if (form == null)
            {
                var exception = new ArgumentNullException(nameof(form));
                Log.Error("Form argument in keyboard class is null", exception);
                throw exception;
            }
            SubscribeToForm(form);
        }

        private void SubscribeToForm(IPressableManipulator<KeyEventArgs> form)
        {
            form.KeyDown += UpdateOnKeyDown;
            form.KeyUp += UpdateOnKeyUp;
        }

        private void UpdateOnKeyDown(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            if (!_pressed.Contains(key))
            {
                _toAdd = key;
                _pressed.Add(_toAdd);
            }
            else
            {
                _toAdd = Keys.None;
            }
        }
        private void UpdateOnKeyUp(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _pressed.Remove(key);
        }
    }
}