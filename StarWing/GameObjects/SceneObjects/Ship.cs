using System;
using System.Collections.Generic;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.Framework;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjects.SceneObjects
{
    public abstract class Ship : PhysicalGameObject, ILivable, IShootable
    {
        public const int StandardMaxHealth = 100;

        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                if (value == _health)
                    return;
                var delta = _health - value;
                _health = value;
                HealthChanged?.Invoke(this, delta);

                if (Health <= 0)
                {
                    Die?.Invoke(this);
                }
            }
        }

        private int _maxHealth;

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                if (value == _maxHealth)
                    return;
                var delta = _maxHealth - value;
                _maxHealth = value;
                MaxHealthChanged?.Invoke(this, delta);
            }
        }

        private List<PowerUp> _powerUps { get; } = new List<PowerUp>();
        private List<PowerUp> _toRemove { get; } = new List<PowerUp>();
        private List<PowerUp> _toAdd { get; } = new List<PowerUp>();

        public void ApplyPowerUp(PowerUp powerUp)
        {
            _toAdd.Add(powerUp);
        }

        public void RemovePowerUp(PowerUp powerUp)
        {
            _toRemove.Add(powerUp);
        }

        public ProjectileFactory ProjectileFactory { get; set; }

        public Ship(IWorld world) : base(world)
        {
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            UpdatePowerUps(gameTime);
            UpdateCoolDown(gameTime);
        }

        private void UpdatePowerUps(GameTime gameTime)
        {
            foreach (var powerUp in _toAdd)
            {
                if (!_powerUps.Contains(powerUp))
                {
                    _powerUps.Add(powerUp);
                }
            }

            foreach (var powerUp in _toRemove)
            {
                _powerUps.Remove(powerUp);
            }

            _powerUps.ForEach(up => up.Update(gameTime));
        }


        private void UpdateCoolDown(GameTime gameTime)
        {
            if (CoolDown > TimeSpan.Zero)
            {
                var coolDown = CoolDown - gameTime.SinceLastUpdate;
                CoolDown = coolDown < TimeSpan.Zero
                               ? TimeSpan.Zero
                               : coolDown;
            }
        }

        public event ILivable.HealthChangedDelegate MaxHealthChanged;
        public event ILivable.HealthChangedDelegate HealthChanged;
        public event ILivable.LivableDiedDelegate Die;
        public int Damage { get; set; }
        public TimeSpan CoolDown { get; set; }
        public TimeSpan MaxCoolDown { get; set; }
        public void Shoot(Vector2D direction)
        {
            if (CoolDown > TimeSpan.Zero)
                return;
            var projectile = ProjectileFactory.Create(World,this, Damage, direction);
            World.RegisterGameObject(projectile);
            CoolDown += MaxCoolDown;
        }
    }
}