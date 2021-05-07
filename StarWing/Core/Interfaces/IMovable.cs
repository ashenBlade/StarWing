using System.Numerics;
using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface IMovable
    {
        float Velocity { get; set; }
        Vector2D Direction { get; set; }
    }
}