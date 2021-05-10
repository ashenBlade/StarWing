using System;
using StarWing.Core;
using StarWing.Framework;
using StarWing.GameObjects.Implementations;

namespace StarWing.GameObjects.Manager
{
    public class PowerUpManager : Manager
    {
        private PickUpFactory _pickUpFactory;
        private readonly TimeSpan _minSpawnTime;
        private TimeSpan _lastSpawnTime;
        private TimeSpan _nextSpawnTime;
        public PowerUpManager(PickUpFactory pickUpFactory, TimeSpan minSpawnTime)
        {
            _pickUpFactory = pickUpFactory;

            _minSpawnTime = minSpawnTime;
            _lastSpawnTime = TimeSpan.Zero;
            _nextSpawnTime = GetNextSpawnTime(_minSpawnTime);
        }

        private TimeSpan GetNextSpawnTime(TimeSpan minSpawnTime)
        {
            return minSpawnTime + TimeSpan.FromSeconds(( new Random() ).Next(0, 30));
        }

        public override void Initialize(IWorld world)
        {
            base.Initialize(world);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _lastSpawnTime += gameTime.SinceLastUpdate;
            if (_lastSpawnTime > _nextSpawnTime)
            {
                _lastSpawnTime = TimeSpan.Zero;
                var pickUp = _pickUpFactory.CreateRandom(World);
                pickUp.Position = GetPickUpRandomPosition();
                World.RegisterGameObject(pickUp);
            }

            _lastSpawnTime += gameTime.SinceLastUpdate;
        }

        private Vector2D GetPickUpRandomPosition()
        {
            var rand = new Random();
            var x = rand.Next(World.Bounds.Left, World.Bounds.Right);
            var y = rand.Next(World.Bounds.Top, World.Bounds.Bottom);
            return new Vector2D(x, y);
        }
    }
}