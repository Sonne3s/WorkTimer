using WorkTimer.DataBase;
using WorkTimer.IHandlers.Home;

namespace WorkTimer.Handlers.Home
{
    public class TasksHandler : ITasksHandler
    {
        private IRepository _repository;

        public TasksHandler(IRepository repository)
        {
            _repository = repository;
        }

        public List<DataBase.WorkingTask> GetAll() => _repository.GetTasks();
    }
}
