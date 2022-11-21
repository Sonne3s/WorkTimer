using WorkTimer.ViewModels.Timer;

namespace WorkTimer.IFillers.Timer
{
    public interface ITimeFiller
    {
        TimeViewModel GetTimeViewModel(long time);
    }
}
