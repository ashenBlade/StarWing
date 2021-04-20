using System;
using System.Diagnostics;
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
        private Controller Controller { get; set; }
        public Sprite Sprite { get; set; }

        #endregion

        public GameObject(Vector2D position, Rectangle bounds, Controller controller, Sprite sprite)
        {
            Position = position;
            Bounds = bounds;
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            Sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
        }

        #region Methods

        public virtual void Update(GameTime gameTime, Input input)
        {
            Controller.Update(gameTime, input);
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