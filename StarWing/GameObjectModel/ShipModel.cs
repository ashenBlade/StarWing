using StarWing.Framework;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.Items;

namespace StarWing.GameObjectModel
{
    public class ShipModel : GameObjectModel
    {
        public float Velocity { get; }
        public int Health { get; }
        public ProjectileFactory ProjectileFactory { get; }

        public ShipModel(Sprite sprite, float velocity, int health, ProjectileFactory projectileFactory) : base(sprite)
        {
            Health = health;
            Velocity = velocity;
            ProjectileFactory = projectileFactory;
        }
    }
}