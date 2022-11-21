using WorkTimer.Fillers;
using WorkTimer.Fillers.Home;
using WorkTimer.Fillers.Task;
using WorkTimer.Fillers.Timer;
using WorkTimer.IFillers;
using WorkTimer.IFillers.Home;
using WorkTimer.IFillers.Task;
using WorkTimer.IFillers.Timer;

namespace WorkTimer.DependencyInjections
{
    public static class Fillers
    {
        public static void AddScoped(IServiceCollection collection)
        {
            collection.AddScoped<IHomeFillers, HomeFillers>();
            collection.AddScoped<ITaskFillers, TaskFillers>();
            collection.AddScoped<ITasksFiller, TasksFiller>();
            collection.AddScoped<ICreateFiller, CreateFiller>();
            collection.AddScoped<ITaskFiller, TaskFiller>();
            collection.AddScoped<IIntervalsFiller, IntervalsFiller>();

            collection.AddScoped<ITimerFillers, TimerFillers>();
            collection.AddScoped<ITimeFiller, TimeFiller>();
        }
    }
}
