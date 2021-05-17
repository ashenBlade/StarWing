namespace StarWing.Core.EventManager
{
    public class GameEvent
    {
        private object _sender;

        public GameEvent(object sender)
        {
            _sender = sender;
        }

        public object Sender
        {
            get
            {
                return _sender;
            }
        }        
    }
}