using WorkTimer.DataBase;
using WorkTimer.IHandlers.Timer;

namespace WorkTimer.Handlers.Timer
{
    public class UpdateHandler : IUpdateHandler
    {
        private IRepository _repository;

        public UpdateHandler(IRepository repository)
        {
            _repository = repository;
        }

        public WorkingInterval Update()
        {
            return _repository.UpdateIntervalEndTime();
        }

        public IdleInterval UpdateIdle()
        {
            return _repository.UpdateIdleIntervalEndTime();
        }
    }
}
