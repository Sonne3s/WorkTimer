using WorkTimer.IFillers;
using WorkTimer.IFillers.Task;

namespace WorkTimer.Fillers
{
    public class TaskFillers : ITaskFillers
    {
        public ICreateFiller Create { get; set; }

        public TaskFillers(ICreateFiller create)
        {
            this.Create = create;
        }
    }
}
