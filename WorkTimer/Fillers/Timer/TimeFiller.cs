using WorkTimer.IFillers.Timer;
using WorkTimer.ViewModels.Timer;

namespace WorkTimer.Fillers.Timer
{
    public class TimeFiller : ITimeFiller
    {
        public TimeViewModel GetTimeViewModel(long time)
            => new TimeViewModel((long)time);
    }
}
