using WorkTimer.DataBase;

namespace WorkTimer.IHandlers.Timer
{
    public interface IUpdateHandler
    {
        WorkingInterval Update();

        IdleInterval UpdateIdle();
    }
}
