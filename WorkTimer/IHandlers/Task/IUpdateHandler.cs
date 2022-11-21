using WorkTimer.DataBase;

namespace WorkTimer.IHandlers.Task
{
    public interface IUpdateHandler
    {
        WorkingTask? Update(Guid id, string name, int priority, string description);
    }
}
