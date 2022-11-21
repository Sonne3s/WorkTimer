using WorkTimer.DataBase;
using WorkTimer.IServices;

namespace WorkTimer.Services
{
    public partial class TimerService : ITimerService
    {
        private const int _secondMultiplier = 1000;
        private const int _minuteMultiplier = 60;

        private IRepository _repository;
        private Core _core;
        private Timer?_timer;

        public int Perion { get; set; } = _minuteMultiplier * _secondMultiplier;

        public TimerService(/*IRepository repository*/)
        {
            this._repository = new Repository();
            this._core = new Core(this._repository);
        }

        public bool Start()
        {
            this.Clear();
            this._core.IsPaused = false;
            _core.CreateWorkingInterval(_core.GetOrCreatWorkingDay());
            this._timer = new Timer(this._core.Update, this._timer, default(int), this.Perion);

            return true;
        }

        public bool Pause()
        {
            this.Clear();
            this._core.IsPaused = true;
            _core.CreateIdleInterval(_core.GetOrCreatWorkingDay());
            this._timer = new Timer(this._core.UpdateIdle, this._timer, default(int), this.Perion);

            return true;
        }

        public bool Stop()
        {
            this.Clear();

            return true;
        }

        private void Clear()
        {
            if(this._timer != null)
            {
                this._timer.Dispose();
                this._timer = null;
            }
        }

        private class Core
        {
            private IRepository _repository;
            private const int _workingHoursCount = 8;

            public bool IsPaused { get; set; }
    
            public Core(IRepository repository)
            {
                _repository = repository;
            }

            //GetOrCreatWorkingDay
            public WorkingDay GetOrCreatWorkingDay()
                => this.GetOrCreatWorkingDay(_repository.GetLastDay());
    
            private WorkingDay GetOrCreatWorkingDay(WorkingDay? day)
                => day == null || this.GetHousrPerDay(day).TotalHours > Core._workingHoursCount
                    ? this._repository.CreateDay()
                    : day;
    
            private TimeSpan GetHousrPerDay(WorkingDay day)
                => new TimeSpan(
                    day.Intervals.Sum(
                        i => i.EndTime.HasValue
                            ? i.EndTime.Value.Subtract(i.StartTime).Ticks
                            : default(int)));

            //CreateWorkingInterval
            public WorkingInterval CreateWorkingInterval(WorkingDay day)
                => _repository.CreateWorkingInterval(day);

            //CreateIdleInterval
            public IdleInterval CreateIdleInterval(WorkingDay day)
                => _repository.CreateIdleInterval(day);

            //Update
            public void Update(Object timer)
            {                
                if (!this.IsPaused)
                {
                    _repository.UpdateIntervalEndTime();
                }
            }

            //UpdateIdle
            public void UpdateIdle(Object timer)
            {
                if (this.IsPaused)
                {
                    _repository.UpdateIdleIntervalEndTime();
                }
            }
        }
    }
}
