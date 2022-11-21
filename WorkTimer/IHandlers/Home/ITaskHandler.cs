using WorkTimer.DataBase;

namespace WorkTimer.IHandlers.Home
{
    public interface ITaskHandler
    {
        WorkingTask Get(Guid id);
    }
}
