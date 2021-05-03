using System.Numerics;
using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface IMovable
    {
        float Velocity { get; }
        Vector2D Direction { get; }
        void Move(Vector2D direction);
        void IncreaseVelocity(uint delta);
        void DecreaseVelocity(uint delta);
    }
}