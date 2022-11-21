using WorkTimer.IHandlers.Timer;

namespace WorkTimer.IHandlers
{
    public interface ITimerHandlers
    {
        IUpdateHandler Update { get; set; }

        IStartHandler Start { get; set; }              

        IPauseHandler Pause { get; set; }

        IStopHandler Stop { get; set; }

        ITimeHandler Time { get; set; }
    }
}
