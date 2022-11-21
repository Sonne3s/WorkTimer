using WorkTimer.Handlers;
using WorkTimer.Handlers.Home;
using WorkTimer.Handlers.Task;
using WorkTimer.Handlers.Timer;
using WorkTimer.IHandlers;
using WorkTimer.IHandlers.Home;
using WorkTimer.IHandlers.Task;
using WorkTimer.IHandlers.Timer;

namespace WorkTimer.DependencyInjections
{
    public static class Handlers
    {
        public static void AddScoped(IServiceCollection collection)
        {
            collection.AddScoped<IHomeHandlers, HomeHandlers>();
            collection.AddScoped<ITaskHandler, TaskHandler>();
            collection.AddScoped<ITasksHandler, TasksHandler>();
            collection.AddScoped<IIntervalsHandler, IntervalsHandler>();

            collection.AddScoped<ITaskHandlers, TaskHandlers>();
            collection.AddScoped<ICreateHandler, CreateHandler>();
            collection.AddScoped<IHandlers.Task.IUpdateHandler, WorkTimer.Handlers.Task.UpdateHandler>();            

            collection.AddScoped<ITimerHandlers, TimerHandlers>();
            collection.AddScoped<IStartHandler, StartHandler>();
            collection.AddScoped<IStopHandler, StopHandler>();
            collection.AddScoped<IPauseHandler, PauseHandler>();
            collection.AddScoped<ITimeHandler, TimeHandler>();
            collection.AddScoped<IHandlers.Timer.IUpdateHandler, WorkTimer.Handlers.Timer.UpdateHandler>();
        }
    }
}
