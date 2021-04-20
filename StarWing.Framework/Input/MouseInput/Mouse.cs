using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Mouse : IMouse
    {
        // Better to store it in integer
        private List<MouseButtons> _pressed;
        private ScrollDirection _scrollDirection;
        private MouseButtons _justPressed;
        public Point Position { get; private set; }

        public MouseStatus Status
        {
            get
            {
                // Current values
                var justPressed = _justPressed;
                var scrollDirection = _scrollDirection;

                // Clear on update
                _justPressed = MouseButtons.None;
                _scrollDirection = ScrollDirection.None;

                return new MouseStatus(Position, _pressed, justPressed, scrollDirection);
            }
        }

        public Mouse(IMouseManipulator mouseManipulator)
        {
            if (mouseManipulator == null)
            {
                var exception = new ArgumentNullException(nameof(mouseManipulator));
                Log.Error("Mouse manipulator argument in Mouse class constructor is null",exception);
                throw exception;
            }

            mouseManipulator.KeyDown += UpdateOnMouseDown;
            mouseManipulator.KeyUp += UpdateOnMouseUp;
            mouseManipulator.Move += UpdateOnMouseMove;
            mouseManipulator.Scroll += UpdateOnMouseScroll;

            _justPressed = new();
            _pressed = new();
            Position = Point.Empty;
            _scrollDirection = ScrollDirection.None;
        }

        private void UpdateOnMouseScroll(object? sender, ScrollEventArgs e)
        {
            _scrollDirection = e.Direction;
        }

        private void UpdateOnMouseMove(object? sender, MouseEventArgs e)
        {
            Position = e.Location;
        }

        private void UpdateOnMouseDown(object? sender, MouseEventArgs e)
        {
            var button = e.Button;

            // Pressed first time
            if (!_pressed.Contains(button))
            {
                _justPressed = button;
                _pressed.Add(button);
            }
            else
            {
                _justPressed = MouseButtons.None;
            }
        }

        private void UpdateOnMouseUp(object? sender, MouseEventArgs e)
        {
            _pressed.Remove(e.Button);
        }
    }
}