using System;
using System.Collections.Generic;
using System.Linq;
using StarWing.Core;
using StarWing.GameObjectModel;
using StarWing.GameObjects.Items;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Implementations
{
    public class PickUpFactory
    {
        private List<PowerUpModel> _powerUps;
        public PickUpFactory(IEnumerable<PowerUpModel> models)
        {
            _powerUps = models.ToList();
        }

        public PickUp CreateRandom(IWorld world)
        {
            return CreatePowerUp(world);
        }

        public PickUp CreatePowerUp(IWorld world)
        {
            var rand = new Random();
            var model = _powerUps[rand.Next(0, _powerUps.Count - 1)];
            var powerUp = new PowerUp(model.LifeTime, model.Applier, model.TearDown, model.Update);
            var pickUp = new PickUp(world, powerUp, TimeSpan.FromSeconds(10))
                         {
                             Bounds = model.Sprite.Size, Sprite = model.Sprite
                         };
            return pickUp;
        }
    }
}