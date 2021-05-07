using System.Drawing;
using System.Windows.Forms;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.GameObjects.SceneObjects
{
    public class Player : Ship
    {
        public Player(IWorld world): base(world)
        { }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            // Movement update
            var keyboard = input.KeyboardStatus;
            var direction = Vector2D.Zero;
            if (keyboard.IsKeyDown(Keys.Up))
            {
                direction += Vector2D.Up;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                direction += Vector2D.Down;
            }

            if (keyboard.IsKeyDown(Keys.Right))
            {
                direction += Vector2D.Right;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                direction += Vector2D.Left;
            }

            Direction = direction;
            var newBounds = new Rectangle(Position + Direction * Velocity * (float) gameTime.SinceLastUpdate.TotalMilliseconds, Bounds);
            if (World.Bounds.Contains(newBounds))
            {
                Position = newBounds.Location;
            }

            if (keyboard.IsKeyDown(Keys.Space))
            {
                Shoot();
            }
        }
    }
}