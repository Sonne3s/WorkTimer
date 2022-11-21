using WorkTimer.DataBase;
using WorkTimer.IHandlers.Task;

namespace WorkTimer.Handlers.Task
{
    public class UpdateHandler : IUpdateHandler
    {
        private IRepository _repository;

        public UpdateHandler(IRepository repository)
        {
            _repository = repository;
        }

        public WorkingTask? Update(Guid id, string name, int priority, string description) 
            => _repository.UpdateTask(id, name, priority, description);
    }
}
