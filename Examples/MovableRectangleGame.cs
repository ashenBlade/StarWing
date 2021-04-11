using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.Framework.Primitives;

namespace Examples
{
    public class MovableRectangleGame : Game
    {
        private Vector2D _rectanglePosition;
        private Rectangle _rectangle;
        private Vector2D _mousePosition;
        public MovableRectangleGame() { }

        protected override void OnLoad()
        {
            _rectanglePosition = Vector2D.Zero;
            _mousePosition = Vector2D.Zero;
            _rectangle = new Rectangle(_rectanglePosition, new Size(100, 100));
        }

        protected override void Update(IGameTime gameTime)
        {
            // Mouse input example
            var mouse = Mouse.Status;
            _mousePosition = mouse.Position;
            if (mouse.IsButtonPressed(MouseButtons.Left))
            {
                _rectanglePosition = mouse.Position;
                return;
            }

            // Keyboard input example
            var keyboard = Keyboard.Status;
            var velocity = Vector2D.Zero;
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                velocity += Vector2D.Down;
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                velocity += Vector2D.Up;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                velocity += Vector2D.Left;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                velocity += Vector2D.Right;
            }

            _rectanglePosition += velocity;
        }

        protected override void Render(Graphics graphics)
        {
            // Draw rectangle
            graphics.FillRectangle(Brushes.Red, new RectangleF(_rectanglePosition.X,_rectanglePosition.Y, _rectangle.Width, _rectangle.Height));

            // Show mouse position
            var font = new Font(FontFamily.GenericMonospace, 12);
            var textPosition = new Vector2D(100, 100);
            graphics.DrawString($"Mouse position: X: {_mousePosition.X} Y: {_mousePosition.Y}", font, Brushes.Black, textPosition);
        }
    }
}