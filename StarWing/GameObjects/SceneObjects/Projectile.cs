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
        public TimeSpan LifeTime { get; set; }

        public Projectile(IWorld world) : base(world)
        {
            LifeTime = TimeSpan.FromSeconds(4);
        }

        public override void OnCollision(GameObject collider)
        {
            if (collider == Owner || collider is not Ship ship)
                return;
            ship.Health -= Damage;
            World.RemoveGameObject(this);
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            Position += Direction * Velocity * (float) gameTime.SinceLastUpdate.TotalMilliseconds / 2;
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