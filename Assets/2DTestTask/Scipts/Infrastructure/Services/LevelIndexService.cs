using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service
{
    public class LevelIndexService : ILevelIndexService
    {
        public int LevelIndex { get; private set; } = 1;

        
        public void SetLevelIndex(int levelIndex)
        {
            LevelIndex = Mathf.Clamp(levelIndex, 1, int.MaxValue);
        }
    }
}