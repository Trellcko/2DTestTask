using System.Threading.Tasks;
using Constants;
using Trell.TwoDTestTask.Gameplay.Level;
using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class LoadGameState : BaseStateWithPayLoad<int>
    {
        private readonly ISceneService _sceneService;
        private readonly IGameFactory _factory;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private int _levelIndex;

        public LoadGameState(StateMachine machine, ISceneService sceneService, IGameFactory factory, IAssetProvider assetProvider, IStaticDataService staticDataService) : base(machine)
        {
            _factory = factory;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _sceneService = sceneService;
        }

        public override void  Enter(int level)
        {
            _levelIndex = level;
            _sceneService.Load(SceneName.GameScene, OnLoaded);
            _factory.CleanUp();
        }

        private async void OnLoaded()
        {
            _factory.RefreshContainer();

            await CreateLevel();

            GoToState<GameLoopState>();
        }

        private async Task CreateLevel()
        {
            LevelData level = await _staticDataService.GetLevelData(_levelIndex);
            _factory.CreatePlayer(level.PlayerPosition);
            Object.Instantiate(await _assetProvider.Load<GameObject>(level.LevelPrefab));
            foreach (EnemyConfig enemyConfig in level.EnemyConfig)
            {
                _factory.CreateEnemy(enemyConfig.Type, enemyConfig.SpawnPosition,
                    enemyConfig.Positions);
            }
        }
    }
}