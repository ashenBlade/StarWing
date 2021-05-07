using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.GameObjects.SceneObjects
{
    public class Projectile : PhysicalGameObject
    {
        public Ship Owner { get; set; }
        public int Damage { get; set; }
        public TimeSpan LifeTime { get; set; } = TimeSpan.FromSeconds(5);

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
            if (!IsInGameBounds())
            {
                World.RemoveGameObject(this);
            }
        }

        private bool IsInGameBounds()
        {
            return World.Bounds.Contains(BoundingBox) || World.Bounds.IntersectsWith(BoundingBox);
        }
    }
}