using System;
using System.Collections.Generic;
using System.Drawing;
using StarWing.Framework;
using StarWing.PickUpItem;

namespace StarWing
{
    public abstract class Unit : GameObject
    {
        private int _maxHealth;
        private int _health;

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }
        public int Health
        {
            get => _health;
            set
            {
                if (value > _maxHealth || value > _health)
                {
                    Heal?.Invoke(this, EventArgs.Empty);
                    _health = value;
                }
                else if (value < _health)
                {
                    TakeDamage?.Invoke(this, EventArgs.Empty);
                    _health = value;
                }
            }
        }

        private Weapon _weapon;
        public Weapon Weapon
        {
            get => _weapon;
            set
            {
                if (_weapon != value)
                {
                    _weapon = value;
                    WeaponChanged?.Invoke(this, value);
                }
            } }

        protected Unit(Vector2D position, Rectangle bounds, Controller controller, Sprite sprite, Weapon weapon, int health, int maxHealth) :
            base(position, bounds, controller, sprite)
        {
            Weapon = weapon;
            Health = health;
            MaxHealth = health;
        }

        public void Shoot()
        {
            Weapon?.Shoot();
        }


        public event EventHandler<Weapon> WeaponChanged;
        public event EventHandler Heal;
        public event EventHandler TakeDamage;
        public event EventHandler Kill;

    }
}