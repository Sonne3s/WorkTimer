using Microsoft.AspNetCore.Mvc;
using WorkTimer.IFillers;
using WorkTimer.IHandlers;

namespace WorkTimer.Controllers
{
    public class TimerController : Controller
    {
        ITimerHandlers _handler;
        ITimerFillers _filler;

        public TimerController(ITimerHandlers handler, ITimerFillers filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public JsonResult Time()
            => Json(_filler.Time.GetTimeViewModel(_handler.Time.Get()));

        public JsonResult Start()
            => Json(_handler.Start.Start());

        public JsonResult Pause()
            => Json(_handler.Pause.Pause());

        public JsonResult Stop()
            => Json(_handler.Stop.Stop());
    }
}
