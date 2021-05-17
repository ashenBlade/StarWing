using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWing.Core.EventManager
{
    public delegate void GameEventHandler(GameEvent gameEvent);
    class EventManager : IEventManager
    {
        private Dictionary<object, GameEventHandler> _listeners; //object = Ship or Enemy
        private List<GameEvent> _newEvents;
        private List<GameEvent> _currentEvents;
        private bool isProcessing;

        private EventManager()
        {
            _listeners = new Dictionary<object, GameEventHandler>();
            _newEvents = new List<GameEvent>();
            _currentEvents = new List<GameEvent>();
            isProcessing = false;
        }

        public void Raise(GameEvent gameEvent)
        {
            _newEvents.Add(gameEvent);
        }

        public void RegisterListener(GameEvent gameEvent)
        {
        }

        public void RemoveListener(GameEvent gameEvent)
        {
        }
    }
}
