using System.Numerics;
using StarWing.Framework;

namespace StarWing.ECS
{
    public class MoveComponent
    {
        public Vector2D Direction { get; set; }
        public float Velocity { get; set; }
        public float MaxVelocity { get; set; }
    }
}