using Microsoft.AspNetCore.Mvc.Rendering;
using WorkTimer.DataBase;
using WorkTimer.Extensions;
using WorkTimer.IFillers.Home;
using WorkTimer.ViewModels.Home;

namespace WorkTimer.Fillers.Home
{
    public class TaskFiller : ITaskFiller
    {
        public TaskViewModel GetTaskViewModel(WorkingTask task)
            => new TaskViewModel(
                task.Id, 
                task.Number, 
                task.Name, 
                task.Description, 
                this.ToListItem(task.Priority), 
                this.ToListItem(task.SubTasks));

        private List<SelectListItem> ToListItem(Priority priority)
            => Enum
                .GetValues<Priority>().Select(p => new SelectListItem(Enum.GetName(p), p.ToString("d")))
                .SetSelectedItem(priority.ToString("d"))
                .ToList();

        private List<SelectListItem> ToListItem(List<WorkingTask> childTasks)
            => childTasks == null 
                ? new List<SelectListItem>()
                : childTasks.Select(t => new SelectListItem(t.Id.ToString(), t.Name)).ToList();
    }
}
