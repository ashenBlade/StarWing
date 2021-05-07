using System;
using StarWing.Core;
using StarWing.ECS;
using StarWing.Framework;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjects.SceneObjects
{
    public class PickUp : GameObject
    {
        public TimeSpan LifeTime { get; set; }
        public Item Item { get; set; }

        public PickUp(IWorld world) : base(world)
        {

        }

        public override void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
            if (collider is Player player)
            {
                Item.Apply(player);
            }
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            LifeTime -= gameTime.SinceLastUpdate;
        }
    }
}