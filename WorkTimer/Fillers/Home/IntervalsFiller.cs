using WorkTimer.DataBase;
using WorkTimer.IFillers.Home;
using WorkTimer.ViewModels.Home;
using WorkTimer.ViewModels.Home.Intervals;

namespace WorkTimer.Fillers.Home
{
    public class IntervalsFiller : IIntervalsFiller
    {
        public IntervalsViewModel GetIntervalsViewModel(List<WorkingDay> days)
            => new IntervalsViewModel(this.GetWorkingDaysViewModels(days));

        private List<WorkingDayViewModel> GetWorkingDaysViewModels(List<WorkingDay> days)
            => days.Select(d => this.GetWorkingDaysViewModel(d)).ToList();

        private WorkingDayViewModel GetWorkingDaysViewModel(WorkingDay day)
            => new WorkingDayViewModel(this.GetWorkingIntervalsViewModels(day.Intervals));

        private List<WorkingIntervalViewModel> GetWorkingIntervalsViewModels(List<WorkingInterval> intervals)
            => intervals.Select(i => this.GetWorkingIntervalsViewModel(i)).ToList();

        private WorkingIntervalViewModel GetWorkingIntervalsViewModel(WorkingInterval intervals)
            => new WorkingIntervalViewModel(intervals.EndTime.Value - intervals.StartTime);
    }
}
