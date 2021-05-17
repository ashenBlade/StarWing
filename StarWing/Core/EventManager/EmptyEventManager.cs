namespace StarWing.Core.EventManager
{
    public class EmptyEventManager : IEventManager
    {
        public void Raise(GameEvent gameEvent)
        {
        }

        public void RegisterListener(GameEvent gameEvent)
        {
        }

        public void RemoveListener(GameEvent gameEvent)
        {
        }
    }
}