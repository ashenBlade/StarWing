using System;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.Framework;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjects.SceneObjects
{
    public class Enemy : Ship

    {
        public override void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
            if (collider is Ship)
            {
                OnDie(this);
                World.RemoveGameObject(this);
            }
        }

        public Enemy(IWorld world) : base(world) { }
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            Position += Direction * Velocity * (float) gameTime.SinceLastUpdate.TotalMilliseconds / 2;
            Shoot(Direction);
        }

        protected override void OnDie(ILivable livable)
        {
            base.OnDie(livable);
        }
    }
}