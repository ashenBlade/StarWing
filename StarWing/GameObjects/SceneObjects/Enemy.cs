using StarWing.Core;
using StarWing.Framework;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjects.SceneObjects
{
    public class Enemy : Ship

    {
        public Enemy(IWorld world) : base(world) { }
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            Position += Direction * Velocity;
            Shoot(Direction);
        }
    }
}