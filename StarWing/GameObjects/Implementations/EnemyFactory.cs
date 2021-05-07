using System;
using System.Collections.Generic;
using System.Linq;
using StarWing.Core;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Implementations
{
    public class EnemyFactory
    {
        private List<ShipModel> _shipModels;
        private IWorld _world;
        public EnemyFactory(IEnumerable<ShipModel> shipModels, IWorld world)
        {
            _shipModels = shipModels.ToList();
            _world = world;
        }

        public Enemy CreateRandom()
        {
            var model = GetRandomModel();
            var enemy = new Enemy(_world)
                        {
                            ProjectileFactory = model.ProjectileFactory,
                            Health = model.Health,
                            Velocity = model.Velocity,
                            Sprite = model.Sprite,
                            Direction = Vector2D.Down,
                            Bounds = model.Sprite.Size,
                            MaxHealth = model.Health,
                            MaxCoolDown = model.CoolDown,
                            CoolDown = model.CoolDown
                        };
            return enemy;
        }

        private ShipModel GetRandomModel()
        {
            var random = new Random().Next(0, _shipModels.Count - 1);
            var model = _shipModels[random];
            return model;
        }
    }
}