using WorkTimer.IFillers.Home;

namespace WorkTimer.IFillers
{
    public interface IHomeFillers
    {
        ITasksFiller Tasks { get; set; }

        ITaskFiller Task { get; set; }

        IIntervalsFiller Intervals { get; set; }
    }
}
