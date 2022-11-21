using WorkTimer.DataBase;
using WorkTimer.IHandlers.Timer;
using WorkTimer.IServices;

namespace WorkTimer.Handlers.Timer
{
    public class PauseHandler : IPauseHandler
    {
        private ITimerService _timer;

        public PauseHandler(ITimerService timer)
        {
            _timer = timer;
        }

        public bool Pause() => _timer.Pause();
    }
}
