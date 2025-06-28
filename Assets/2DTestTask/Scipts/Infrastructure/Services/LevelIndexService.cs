using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service
{
    public class LevelIndexService : ILevelIndexService, IInitializable
    {
        private IStaticDataService _staticDataService;
        public int LevelIndex { get; private set; }
        public int LevelValue => LevelIndex + 1;

        public int MaxLevel { get; private set; }
        
        public LevelIndexService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public async void Initialize()
        {
            MaxLevel = (await _staticDataService.GetLevelData()).LevelData.Count;
        }

        public void SetLevelIndex(int levelIndex)
        {
            LevelIndex = Mathf.Clamp(levelIndex, 0, MaxLevel - 1);
        }
    }
}