using WorkTimer.DataBase;
using WorkTimer.IHandlers.Task;

namespace WorkTimer.Handlers.Task
{
    public class CreateHandler : ICreateHandler
    {
        private IRepository _repository;

        public CreateHandler(IRepository repository)
        {
            _repository = repository;
        }

        public WorkingTask Create(string name) => _repository.CreateTask(name);
    }
}
