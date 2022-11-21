using WorkTimer.DataBase;

namespace WorkTimer.IHandlers.Home
{
    public interface IIntervalsHandler
    {
        List<WorkingDay> GetAll();
    }
}
