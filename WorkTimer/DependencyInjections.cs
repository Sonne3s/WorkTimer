using WorkTimer.DataBase;
using WorkTimer.IServices;
using WorkTimer.Services;

namespace WorkTimer
{
    public static class DependencyInjection
    {
        public static void AddScoped(IServiceCollection collection)
        {
            collection.AddSingleton<ITimerService, TimerService>();
            collection.AddScoped<IRepository, Repository>();
            DependencyInjections.Fillers.AddScoped(collection);
            DependencyInjections.Handlers.AddScoped(collection);
        }
    }
}
