using WorkTimer.IHandlers;
using WorkTimer.IHandlers.Task;

namespace WorkTimer.Handlers
{
    public class TaskHandlers : ITaskHandlers
    {
        public ICreateHandler Create { get; set; }

        public IUpdateHandler Update { get; set; }

        public TaskHandlers(ICreateHandler create, IUpdateHandler update)
        {
            this.Create = create;
            this.Update = update;
        }
    }
}
