using System.Text.Json;
using WorkTimer.IFillers.Task;
using WorkTimer.ViewModels.Task;

namespace WorkTimer.Fillers.Task
{
    public class CreateFiller : ICreateFiller
    {
        public CreateViewModel GetCreateViewModel(DataBase.WorkingTask task)
            => new CreateViewModel(task.Id, task.Name);
    }
}
