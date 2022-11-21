namespace WorkTimer.IServices
{
    public interface ITimerService
    {
        int Perion { get; set; }

        bool Start();

        bool Pause();

        bool Stop();
    }
}
