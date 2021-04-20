using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public class GameObject
    {
        #region Properties

        public Vector2D Position { get; set; }
        public Rectangle Bounds { get; set; }
        public Controller Controller { get; set; }
        public Sprite Sprite { get; set; }

        #endregion

        #region Methods

        public virtual void Update(GameTime gameTime, Input input)
        {

        }

        public virtual void Render(Graphics graphics)
        {
            graphics.DrawImage(Sprite.Image, Position);
        }

        public virtual void DestroySelf()
        {
            OnDestroy();
        }

        protected virtual void OnDestroy()
        {
            Destroy?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public event EventHandler Destroy;

    }
}