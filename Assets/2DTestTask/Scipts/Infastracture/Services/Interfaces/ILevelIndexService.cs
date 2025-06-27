namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface ILevelIndexService
    {
        int LevelIndex { get; }
        void SetLevelIndex(int levelIndex);
    }
}