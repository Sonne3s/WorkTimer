using WorkTimer.DataBase;
using WorkTimer.IHandlers.Home;

namespace WorkTimer.Handlers.Home
{
    public class IntervalsHandler : IIntervalsHandler
    {
        private IRepository _repository;

        public IntervalsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public List<WorkingDay> GetAll()
        {
            return _repository.GetWorkingDays();
        }
    }
}