using WorkTimer.IFillers;
using WorkTimer.IFillers.Timer;

namespace WorkTimer.Fillers
{
    public class TimerFillers : ITimerFillers
    {
        public ITimeFiller Time { get; set; }

        public TimerFillers(ITimeFiller time)
        {
            this.Time = time;
        }
    }
}
