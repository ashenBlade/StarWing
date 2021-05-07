using System;
using System.Drawing;
using StarWing.Core;
using StarWing.Core.Interfaces;
using StarWing.ECS;
using StarWing.Framework;
using IRenderable = StarWing.Core.Interfaces.IRenderable;

namespace StarWing
{
    public abstract class GameObject : IRenderable, ITransform, ICollidable
    {
        #region Properties
        protected IWorld World { get; }
        public Sprite Sprite { get; set; }
        public bool IsVisible { get; set; }
        public Vector2D Position { get; set; }
        public Size Bounds { get; set; }
        public Rectangle BoundingBox { get; set; }
        #endregion

        public GameObject(IWorld world)
        {
            IsVisible = true;
            World = world;
        }

        public virtual void Update(GameTime gameTime, Input input)
        { }

        public virtual void Render(Graphics graphics)
        {
            if (IsVisible)
            {
                graphics.DrawSprite(Sprite, Position);
            }
        }

        public virtual void OnCollision(GameObject collider)
        { }
    }
}
