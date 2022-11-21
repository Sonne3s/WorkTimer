using Microsoft.AspNetCore.Mvc;
using WorkTimer.IFillers;
using WorkTimer.IHandlers;

namespace WorkTimer.Controllers
{
    public class TaskController : Controller
    {
        private ITaskHandlers _handler;
        private ITaskFillers _filler;

        public TaskController(ITaskHandlers handler, ITaskFillers filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public JsonResult Create(string name) => Json(_filler.Create.GetCreateViewModel(_handler.Create.Create(name)));

        public JsonResult Update(Guid id, string name, int priority, string description) 
            => Json(_handler.Update.Update(id, name, priority, description));
    }
}
