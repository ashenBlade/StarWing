using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface ICollidable
    {
        SizeF Bounds { get; set; }
        RectangleF BoundingBox { get; set; }
        void OnCollision(GameObject collider);
    }
}