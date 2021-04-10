namespace StarWing.Framework.Primitives
{
    public struct Ray2D
    {
        public Vector2D Origin { get; }
        public Vector2D Direction { get; }

        public Ray2D(Vector2D direction, Vector2D origin)
        {
            Direction = direction;
            Origin = origin;
        }
    }
}