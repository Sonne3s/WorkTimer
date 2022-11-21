using WorkTimer.IHandlers;
using WorkTimer.IHandlers.Timer;

namespace WorkTimer.Handlers
{
    public class TimerHandlers : ITimerHandlers
    {
        public IUpdateHandler Update { get; set; }

        public IStartHandler Start { get; set; }

        public IPauseHandler Pause { get; set; }       

        public IStopHandler Stop { get; set; }

        public ITimeHandler Time { get; set; }

        public TimerHandlers(IStartHandler start, IUpdateHandler update, IPauseHandler pause, IStopHandler stop, ITimeHandler time)
        {
            this.Update = update;
            this.Start = start;
            this.Pause = pause;
            this.Stop = stop;
            this.Time = time;
        }
    }
}
