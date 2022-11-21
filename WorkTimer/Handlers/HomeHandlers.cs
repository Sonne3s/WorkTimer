using WorkTimer.IHandlers;
using WorkTimer.IHandlers.Home;

namespace WorkTimer.Handlers
{
    public class HomeHandlers : IHomeHandlers
    {
        public ITasksHandler Tasks { get; set; }

        public ITaskHandler Task { get; set; }

        public IIntervalsHandler Intervals { get; set; }

        public HomeHandlers(ITasksHandler tasksHandler, ITaskHandler taskHandler, IIntervalsHandler intervalsHandler)
        {
            this.Tasks = tasksHandler;
            this.Task = taskHandler;
            this.Intervals = intervalsHandler;
        }
    }
}
