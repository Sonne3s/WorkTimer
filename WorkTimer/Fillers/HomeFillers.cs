using WorkTimer.IFillers;
using WorkTimer.IFillers.Home;

namespace WorkTimer.Fillers
{
    public class HomeFillers : IHomeFillers
    {
        public ITasksFiller Tasks { get; set; }

        public ITaskFiller Task { get; set; }

        public IIntervalsFiller Intervals { get; set; }

        public HomeFillers(ITasksFiller tasksFiller, ITaskFiller taskFiller, IIntervalsFiller intervals)
        {
            this.Tasks = tasksFiller;
            this.Task = taskFiller;
            this.Intervals = intervals;
        }
    }
}
