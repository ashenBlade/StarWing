namespace StarWing.Core.EventManager
{
    public interface IEventManager
    {
        void Raise(GameEvent gameEvent);
        void RegisterListener(GameEvent gameEvent);
        void RemoveListener(GameEvent gameEvent);
    }
}