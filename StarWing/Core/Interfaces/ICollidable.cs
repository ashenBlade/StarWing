using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface ICollidable
    {
        Size Bounds { get; set; }
        Rectangle BoundingBox { get; set; }
        void OnCollision(GameObject collider);
    }
}