using WorkTimer.IFillers.Task;

namespace WorkTimer.IFillers
{
    public interface ITaskFillers
    {
        ICreateFiller Create { get; set; }
    }
}
