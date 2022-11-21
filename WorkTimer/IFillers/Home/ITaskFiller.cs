using WorkTimer.DataBase;
using WorkTimer.ViewModels.Home;

namespace WorkTimer.IFillers.Home
{
    public interface ITaskFiller
    {
        TaskViewModel GetTaskViewModel(WorkingTask task);
    }
}
