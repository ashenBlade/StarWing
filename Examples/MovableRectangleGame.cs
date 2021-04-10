using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.Framework.Primitives;

namespace Examples
{
    public class MovableRectangleGame : Game
    {
        private Vector2D _position;
        private Rectangle _rectangle;
        public MovableRectangleGame() { }

        protected override void OnLoad()
        {
            _position = Vector2D.Zero;
            _rectangle = new Rectangle(_position, new Size(100, 100));
        }

        protected override void Update(IGameTime gameTime)
        {
            var keyboard = Keyboard.Status;
            var velocity = Vector2D.Zero;
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

            _position += velocity;
        }

        protected override void Render(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Red, _position.X, _position.Y, _rectangle.Width, _rectangle.Height);
        }
    }
}