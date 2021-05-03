using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface ICollidable
    {
        Vector2D Position { get; }
        Size Size { get; }
        Rectangle BoundingBox { get; }
        bool IsCollidable { get; }
        Action<ICollidable> OnCollision { get; }
    }
}