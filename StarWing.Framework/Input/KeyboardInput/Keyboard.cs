using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // It would be better to store it in integers
        private readonly List<Keys> _pressed = new();

        private Keys _justPressed = Keys.None;

        public KeyboardStatus Status
        {
            get
            {
                var justpressed = _justPressed;
                _justPressed = Keys.None;
                return new KeyboardStatus(_pressed, justpressed);
            }
        }

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
            if (!_pressed.Contains(key))
            {
                _justPressed = key;
                _pressed.Add(_justPressed);
            }
            else
            {
                _justPressed = Keys.None;
            }
        }

        private void UpdateOnKeyUp(object? sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _pressed.Remove(key);
            _justPressed = Keys.None;
        }
    }
}