using WorkTimer.ViewModels.Task;

namespace WorkTimer.IFillers.Task
{
    public interface ICreateFiller
    {
        CreateViewModel GetCreateViewModel(DataBase.WorkingTask task);
    }
}
