using System.Drawing;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.ECS;
using StarWing.Framework;

namespace StarWing.GameObjects.SceneObjects
{
    public class Projectile : PhysicalGameObject
    {
        public Ship Owner { get; set; }
        public int Damage { get; set; }

        public Projectile(IWorld world) : base(world)
        { }

        public override void OnCollision(GameObject collider)
        {
            if (collider != Owner &&
                collider is Ship ship)
            {
                ship.Health -= Damage;
                World.RemoveGameObject(this);
            }
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            Position += Direction * Velocity;
        }
    }
}