using WorkTimer.DataBase;
using WorkTimer.IHandlers.Home;

namespace WorkTimer.Handlers.Home
{
    public class TaskHandler : ITaskHandler
    {
        private IRepository _repository;

        public TaskHandler(IRepository repository)
        {
            _repository = repository;
        }

        public WorkingTask Get(Guid id) => _repository.GetTask(id);
    }
}
