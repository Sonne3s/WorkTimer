namespace WorkTimer.DataBase
{
    public interface IRepository
    {
        WorkingTask CreateTask(string name);

        WorkingTask? UpdateTask(Guid id, string name, int priority, string description);

        WorkingTask GetTask(Guid id);

        List<WorkingTask> GetTasks();

        WorkingDay? GetLastDay();

        WorkingDay CreateDay();

        WorkingInterval CreateWorkingInterval(WorkingDay day);

        IdleInterval CreateIdleInterval(WorkingDay day);

        WorkingInterval UpdateIntervalEndTime();

        IdleInterval UpdateIdleIntervalEndTime();

        long GetWorkingIntervalsMillisecondsByWorkingDay();

        List<WorkingDay> GetWorkingDays();
    }
}
