using System;
using System.Drawing;

namespace StarWing.Framework.Primitives
{
    public struct Vector2D
    {
        public float X { get; }
        public float Y { get; }

        private float _length;

        public float Length
        {
            get
            {
                if (_length < 0)
                {
                    _length = ( float ) Math.Sqrt(X * X + Y * Y);
                }
                return _length;
            }
        }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
            _length = -1;
        }

        #region Direction vectors

        public static readonly Vector2D Zero = new Vector2D(0, 0) { _length = 0 };
        public static readonly Vector2D Left = new Vector2D(-1, 0) { _length = 1 };
        public static readonly Vector2D Right = new Vector2D(1, 0) { _length = 1 };
        public static readonly Vector2D Down = new Vector2D(0, 1) { _length = 1 };
        public static readonly Vector2D Up = new Vector2D(0, -1) { _length = 1 };

        #endregion

        #region Overloading of operators

        public static Vector2D operator +(Vector2D first, Vector2D second)
        {
            return new Vector2D(first.X + second.X, first.Y + second.Y);
        }

        public static Vector2D operator -(Vector2D first, Vector2D second)
        {
            return new Vector2D(second.X - first.X, second.Y - first.Y);
        }

        public static Vector2D operator /(Vector2D vector2D, float denominator)
        {
            return new Vector2D(vector2D.X / denominator, vector2D.Y / denominator);
        }

        public static Vector2D operator *(Vector2D vector2D, float multiplier)
        {
            return new Vector2D(vector2D.X * multiplier, vector2D.Y * multiplier);
        }

        public static bool operator ==(Vector2D first, Vector2D second)
        {
            return Math.Abs(first.X - second.X) < 0.01f &&
                   Math.Abs(first.Y - second.Y) < 0.01f;
        }

        public static bool operator !=(Vector2D first, Vector2D second)
        {
            return !( first == second );
        }

        #region Cast operators

        public static implicit operator Vector2D(Point point)
        {
            return new Vector2D(point.X, point.Y);
        }

        public static implicit operator PointF(Vector2D vector)
        {
            return new PointF(vector.X, vector.Y);
        }

        public static implicit operator Point(Vector2D vector)
        {
            return new Point(( int ) vector.X, ( int ) vector.Y);
        }

        #endregion Casting operators

        #endregion Overloading operators
    }
}