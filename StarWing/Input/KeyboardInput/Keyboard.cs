using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // It would be better to store it in integers
        private readonly List<Keys> _pressed = new();
        private Keys _toAdd = Keys.None;

        public KeyboardStatus Status =>
            new KeyboardStatus(_pressed, _toAdd);

        public Keyboard(IKeyboardManipulator manipulator)
        {
            if (manipulator == null)
            {
                var exception = new ArgumentNullException(nameof(manipulator));
                Log.Error("Manipulator instance in keyboard class is null", exception);
                throw exception;
            }
            SubscribeToManipulator(manipulator);
        }

        private void SubscribeToManipulator(IKeyboardManipulator manipulator)
        {
            manipulator.KeyDown += UpdateOnKeyDown;
            manipulator.KeyUp += UpdateOnKeyUp;
        }

        private void UpdateOnKeyDown(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            if (key != Keys.None && !_pressed.Contains(key))
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
            _toAdd = Keys.None;
        }
    }
}