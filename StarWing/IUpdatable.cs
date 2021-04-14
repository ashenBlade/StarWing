namespace StarWing.Framework
{
    public interface IUpdatable
    {
        bool IsEnabled { get; }
        int UpdateOrder { get; }
        void Update(IGameTime gameTime);
    }
}