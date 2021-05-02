using System.Drawing;
using StarWing.Framework;

namespace StarWing.ECS
{
    public class TransformComponent : Component
    {
        private Vector2D _position;
        public Vector2D Position
        {
            get => _position;
            set
            {
                if (_position == value)
                {
                    return;
                }

                var rect = new Rectangle(( int ) value.X, ( int ) value.Y, _bounds.Size.Width, _bounds.Size.Height);
                _bounds = rect;
                _position = value;
            } }

        private Rectangle _bounds;

        public Rectangle Bounds
        {
            get => _bounds;
            set
            {
                if (_bounds == value)
                {
                    return;
                }

                var position = new Vector2D(value.X, value.Y);
                _position = position;
                _bounds = value;
            }
        }

        public float Rotation { get; set; }

        public TransformComponent() :this(Rectangle.Empty, 0)
        { }
        public TransformComponent(Rectangle bounds, float rotation = 0)
            : this(new Vector2D(bounds.X, bounds.Y), bounds.Size, 0)
        { }
        public TransformComponent(Vector2D position, Size size, float rotation = 0)
        {
            Position = position;
            Bounds = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
            Rotation = rotation;
        }
    }
}