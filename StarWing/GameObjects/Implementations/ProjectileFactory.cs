using System;
using StarWing.Core;
using StarWing.ECS;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Implementations
{
    public class ProjectileFactory
    {
        private Sprite _sprite;
        private float _velocity;
        public ProjectileFactory(Sprite sprite, float velocity)
        {
            _sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
            _velocity = velocity;
        }

        public Projectile Create(IWorld world, Ship owner, int damage, Vector2D direction)
        {
            var projectile = new Projectile(world);
            projectile.Direction = direction;
            projectile.Damage = damage;
            projectile.Velocity = _velocity;
            projectile.Position = owner.Position;
            projectile.Owner = owner;
            projectile.Sprite = _sprite;
            projectile.Bounds = _sprite.Size;
            return projectile;
        }
    }
}