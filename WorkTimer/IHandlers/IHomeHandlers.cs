using WorkTimer.IHandlers.Home;

namespace WorkTimer.IHandlers
{
    public interface IHomeHandlers
    {
        ITasksHandler Tasks { get; set; }

        ITaskHandler Task { get; set; }

        IIntervalsHandler Intervals { get; set; }
    }
}
