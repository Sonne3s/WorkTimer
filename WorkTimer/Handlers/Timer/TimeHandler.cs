using WorkTimer.DataBase;
using WorkTimer.IHandlers.Timer;

namespace WorkTimer.Handlers.Timer
{
    public class TimeHandler : ITimeHandler
    {
        private IRepository _repository;

        public TimeHandler(IRepository repository)
        {
            _repository = repository;
        }

        public long Get()
        {
            return _repository.GetWorkingIntervalsMillisecondsByWorkingDay();
        }
    }
}
