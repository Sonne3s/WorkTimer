using WorkTimer.IFillers.Home;
using WorkTimer.ViewModels.Home;
using WorkTimer.ViewModels.Tasks.Home;

namespace WorkTimer.Fillers.Home
{
    public class TasksFiller : ITasksFiller
    {
        public TasksViewModel GetTasksViewModel(List<DataBase.WorkingTask> tasks)
            => new TasksViewModel(tasks.Select(t => this.GetTasksListItemViewModel(t)).ToList());

        private TasksListItemViewModel GetTasksListItemViewModel(DataBase.WorkingTask task)
            => new TasksListItemViewModel(task.Id, task.Name);
    }
}
