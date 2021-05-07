using System;
using System.Collections.Generic;
using System.Linq;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.Framework;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.SceneObjects;
using StarWing.GameWorld;

namespace StarWing.GameObjects.Manager
{
    public class EnemyManager : Manager
    {
        private readonly int _maxEnemiesCount;
        private readonly TimeSpan _spawnTime;
        private Queue<Enemy> _availableEnemies;
        private List<Enemy> _enemies;
        private TimeSpan _lastSpawnTime;
        private int _availableEnemiesCount =>
            _availableEnemies.Count;


        private readonly EnemyFactory _factory;

        public EnemyManager(EnemyFactory factory, int maxEnemiesCount, TimeSpan spawnTime)
        {
            _factory = factory;
            _enemies = new List<Enemy>();
            _availableEnemies = new Queue<Enemy>();
            _spawnTime = spawnTime;
            _lastSpawnTime = TimeSpan.Zero;
            _maxEnemiesCount = maxEnemiesCount;
        }

        public override void Initialize(IWorld world)
        {
            base.Initialize(world);

            InitializeEnemies(_maxEnemiesCount);
        }

        private void InitializeEnemies(int maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                var enemy = _factory.CreateRandom();
                enemy.Die += EnemyOnDie;
                _availableEnemies.Enqueue(enemy);
            }
        }

        private void EnemyOnDie(ILivable livable)
        {
            if (livable is not Enemy enemy)
                return;
            _availableEnemies.Enqueue(enemy);
            _enemies.Remove(enemy);
            World.RemoveGameObject(enemy);
        }

        public override void Update(GameTime gameTime)
        {
            if (_availableEnemiesCount > 1 && _lastSpawnTime > _spawnTime)
            {
                var enemy = GetEnemy();
                World.RegisterGameObject(enemy);
                _enemies.Add(enemy);
                _lastSpawnTime = TimeSpan.Zero;
            }

            _lastSpawnTime += gameTime.SinceLastUpdate;

            foreach (var enemy in _enemies.Where(IsOutOfGameBounds))
            {
                World.RemoveGameObject(enemy);
            }
        }

        private bool IsOutOfGameBounds(Enemy enemy)
        {
            return World.Bounds.Bottom < enemy.Position.Y;
        }

        private Enemy GetEnemy()
        {
            var enemy = _availableEnemies.Dequeue();
            enemy = SetEnemyPosition(enemy);
            enemy = SetEnemyMovement(enemy);
            return enemy;
        }

        private Enemy SetEnemyMovement(Enemy enemy)
        {
            enemy.Direction = Vector2D.Down;
            return enemy;
        }

        private Enemy SetEnemyPosition(Enemy enemy)
        {
            var worldPosition = World.Bounds;
            var random = new Random();
            var positionX = random.Next(0, worldPosition.Width - enemy.Bounds.Width);
            var positionY = worldPosition.Y - enemy.Bounds.Height;
            enemy.Position = new Vector2D(positionX, positionY);
            return enemy;
        }
    }
}