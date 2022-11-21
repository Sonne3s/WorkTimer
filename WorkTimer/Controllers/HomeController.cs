using Microsoft.AspNetCore.Mvc;
using WorkTimer.IFillers;
using WorkTimer.IHandlers;

namespace WorkTimer.Controllers
{
    public class HomeController : Controller
    {
        private IHomeHandlers _handler;
        private IHomeFillers _filler;

        public HomeController(IHomeHandlers handler, IHomeFillers filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public IActionResult Index()
            => RedirectToAction(nameof(this.Timer));

        public IActionResult Timer()
            => View();

        public IActionResult PartialTimer()
            => PartialView(nameof(this.Timer));

        public IActionResult Intervals()
            => View(_filler.Intervals.GetIntervalsViewModel(_handler.Intervals.GetAll()));

        public IActionResult PartialIntervals()
            => PartialView(nameof(this.Intervals), _filler.Intervals.GetIntervalsViewModel(_handler.Intervals.GetAll()));

        public IActionResult Tasks() 
            => View(_filler.Tasks.GetTasksViewModel(_handler.Tasks.GetAll()));

        public IActionResult PartialTasks()
            => PartialView(nameof(this.Tasks), _filler.Tasks.GetTasksViewModel(_handler.Tasks.GetAll()));

        public IActionResult Task(Guid id)
            => View(_filler.Task.GetTaskViewModel(_handler.Task.Get(id)));

        public IActionResult PartialTask(Guid id)
            => PartialView(nameof(this.Task), _filler.Task.GetTaskViewModel(_handler.Task.Get(id)));
    }
}
