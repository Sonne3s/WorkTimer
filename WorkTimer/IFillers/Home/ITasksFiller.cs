using WorkTimer.ViewModels.Home;

namespace WorkTimer.IFillers.Home
{
    public interface ITasksFiller
    {
        TasksViewModel GetTasksViewModel(List<DataBase.WorkingTask> tasks);
    }
}
