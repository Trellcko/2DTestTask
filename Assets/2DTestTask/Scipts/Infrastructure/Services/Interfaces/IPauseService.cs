namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IPauseService
    {
        bool IsPaused { get; }
        public void Pause();
        public void Resume();
    }
}