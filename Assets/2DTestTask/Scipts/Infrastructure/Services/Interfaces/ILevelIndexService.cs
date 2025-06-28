namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service
{
    public interface ILevelIndexService
    {
        int LevelIndex { get; }
        int LevelValue { get; }
        void SetLevelIndex(int levelIndex);
    }
}