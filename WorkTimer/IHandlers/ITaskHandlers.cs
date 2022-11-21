using WorkTimer.IHandlers.Task;

namespace WorkTimer.IHandlers
{
    public interface ITaskHandlers
    {
        ICreateHandler Create { get; set; }

        IUpdateHandler Update { get; set; }
    }
}
