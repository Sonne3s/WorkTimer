using WorkTimer.DataBase;
using WorkTimer.ViewModels.Home;

namespace WorkTimer.IFillers.Home
{
    public interface IIntervalsFiller
    {
        IntervalsViewModel GetIntervalsViewModel(List<WorkingDay> days);
    }
}
