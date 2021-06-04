using System.Drawing;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.Framework;

namespace StarWing.GameObjects.SceneObjects
{
    public class PhysicalGameObject : GameObject, IMovable
    {
        public float Velocity { get; set; }
        public Vector2D Direction { get; set; }
        public PhysicalGameObject(IWorld world)
            : base(world) { }
    }
}