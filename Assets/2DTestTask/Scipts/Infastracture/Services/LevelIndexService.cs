using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service
{
    public class LevelIndexService : ILevelIndexService
    {
        public int LevelIndex { get; private set; }

        
        public void SetLevelIndex(int levelIndex)
        {
            LevelIndex = Mathf.Clamp(levelIndex, 0, int.MaxValue);
        }
    }
}