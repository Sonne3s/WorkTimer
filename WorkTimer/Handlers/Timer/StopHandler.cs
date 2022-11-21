using WorkTimer.DataBase;
using WorkTimer.IHandlers.Timer;
using WorkTimer.IServices;

namespace WorkTimer.Handlers.Timer
{
    public class StopHandler : IStopHandler
    {
        private ITimerService _timer;

        public StopHandler(ITimerService timer)
        {
            _timer = timer;
        }

        public bool Stop() => _timer.Stop();
    }
}
