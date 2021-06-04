using System;
using System.Drawing;
using StarWing.Core;
using StarWing.Core.Interfaces;
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
        private Vector2D _position;
        public Vector2D Position
        {
            get => _position;
            set
            {
                _position = value;
            }
        }

        private SizeF _bounds;
        public SizeF Bounds
        {
            get => _bounds;
            set
            {
                _bounds = value;
            } }

        public RectangleF BoundingBox
        {
            get => new RectangleF(_position, _bounds);
            set
            {
                _position = value.Location;
                _bounds = value.Size;
            }
        }
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
