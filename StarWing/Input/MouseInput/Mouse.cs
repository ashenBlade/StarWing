using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework.Primitives;

namespace StarWing.Framework.Input
{
    public class Mouse : IMouse
    {
        private List<MouseButtons> _pressed;
        private MouseButtons _justPressed;
        public Point Position { get; private set; }

        public MouseStatus Status
        {
            get
            {
                var justPressed = _justPressed;
                _justPressed = (int) MouseButtons.None;
                return new MouseStatus(Position, _pressed, justPressed);
            }
        }

        /// <param name="form">Form to listen input from</param>
        public Mouse(Form form)
        {
            if (form == null)
            {
                var exception = new ArgumentNullException(nameof(form));
                Log.Error("Form in mouse class was null", exception);
                throw exception;
            }

            form.MouseDown += UpdateOnMouseDown;
            form.MouseMove += UpdateMousePosition;
            form.MouseUp += UpdateOnMouseUp;

            _justPressed = new();
            _pressed = new();
            Position = Vector2D.Zero;
        }

        private void UpdateMousePosition(object? sender, MouseEventArgs e)
        {
            Position = e.Location;
        }

        private void UpdateOnMouseDown(object? sender, MouseEventArgs e)
        {
            UpdateMousePosition(sender, e);
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
            UpdateMousePosition(sender, e);
            _pressed.Remove(e.Button);
        }
    }
}