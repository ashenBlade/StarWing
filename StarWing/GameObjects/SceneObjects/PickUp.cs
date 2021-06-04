using System;
using StarWing.Core;
using StarWing.Framework;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjects.SceneObjects
{
    public class PickUp : GameObject
    {
        public TimeSpan LifeTime { get; set; }
        public Item Item { get; set; }

        public PickUp(IWorld world, Item item, TimeSpan lifeTime) : base(world)
        {
            Item = item;
            LifeTime = lifeTime;
        }

        public override void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
            if (collider is Player player)
            {
                Item.Apply(player);
                World.RemoveGameObject(this);
            }
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            LifeTime -= gameTime.SinceLastUpdate;
            if (LifeTime < TimeSpan.Zero)
            {
                World.RemoveGameObject(this);
            }
        }
    }
}