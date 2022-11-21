namespace WorkTimer.IHandlers.Home
{
    public interface ITasksHandler
    {
        List<DataBase.WorkingTask> GetAll();
    }
}
