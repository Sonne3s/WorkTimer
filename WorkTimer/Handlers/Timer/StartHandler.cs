using WorkTimer.DataBase;
using WorkTimer.IHandlers.Timer;
using WorkTimer.IServices;

namespace WorkTimer.Handlers.Timer
{
    public class StartHandler : IStartHandler
    {
        private ITimerService _timer;

        public StartHandler(ITimerService timer)
        {
            _timer = timer;
        }

        public bool Start() => _timer.Start();
    } 
}
