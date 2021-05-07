using System;
using System.Drawing;
using System.Xml.Serialization;

namespace StarWing.Framework
{
    public struct Vector2D
    {
        public float X { get; private set;}
        public float Y { get; private set; }

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

            // Lazy calculating vector length
            _length = -1;
        }

        public void Normalize()
        {
            X = Length == 0
                ? 0
                : X / Length;
            Y = Length == 0
                ? 0
                : Y / Length;
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
            if (denominator == 0)
                throw new DivideByZeroException("Dividing vector by zero");
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

        public bool Equals(Vector2D other)
        {
            return X.Equals(other.X)
                && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2D other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        #region Cast operators

        /// <summary>
        /// Implicitly converts GameWindow coordinates to Math coordinates
        /// </summary>
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