using System;
using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework.Primitives;

namespace StarWing.Framework.Input
{
    public class Mouse : IMouse
    {
        private int _pressed;
        public Point Position { get; private set; }

        public MouseStatus Status =>
            new MouseStatus(Position, _pressed);

        public Mouse(Form form)
        {
            form.MouseDown += UpdateOnMouseDown;
            form.MouseMove += UpdateMousePosition;
            form.MouseUp += UpdateOnMouseUp;

            Position = Point.Empty;
            _pressed = (int) MouseButtons.None;
        }

        private void UpdateMousePosition(object? sender, MouseEventArgs e)
        {
            Position = e.Location;
        }

        private void UpdateOnMouseDown(object? sender, MouseEventArgs e)
        {
            UpdateMousePosition(sender, e);
            _pressed += ( int ) e.Button;
        }

        private void UpdateOnMouseUp(object? sender, MouseEventArgs e)
        {
            UpdateMousePosition(sender, e);
            _pressed -= (int) e.Button;
        }
    }
}