namespace WorkTimer.IHandlers.Task
{
    public interface ICreateHandler
    {
        DataBase.WorkingTask Create(string name);
    }
}
