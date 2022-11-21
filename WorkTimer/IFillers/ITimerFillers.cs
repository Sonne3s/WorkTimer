using WorkTimer.IFillers.Timer;

namespace WorkTimer.IFillers
{
    public interface ITimerFillers
    {
        ITimeFiller Time { get; set; }
    }
}
