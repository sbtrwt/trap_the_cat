

namespace TrapTheCat.Events
{
    public class EventService
    {
        public EventController<bool> OnGameStart { get; private set; }
        public EventController<bool> OnGameOver { get; private set; }
        public EventService()
        {
            OnGameStart = new EventController<bool>();
            OnGameOver = new EventController<bool>();
        }

    }
}