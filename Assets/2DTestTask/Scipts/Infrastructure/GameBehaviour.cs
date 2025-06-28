using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.States;
using Trell.TwoDTestTask.Infrastructure.States;
using Trell.TwoDTestTask.Service.Infrastructure;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure
{
    public class GameBehaviour : IGameBehaviour, ITickable, IInitializable
    {
        private readonly StateMachine _stateMachine = new();

        private ISceneService _sceneService;
        private IGameFactory _gameFactory;
        private IStaticDataService _staticDataService;
        private ILevelIndexService _levelIndexService;
        private IAssetProvider _assetProvider;
        private IPopupFactory _popupFactory;

        [Inject]
        private void Construct(ISceneService sceneService, IGameFactory gameFactory, 
            IStaticDataService staticDataService, ILevelIndexService levelIndexService,
            IAssetProvider assetProvider, IPopupFactory popupFactory)
        {
            _popupFactory = popupFactory;
            _assetProvider = assetProvider;
            _levelIndexService = levelIndexService;
            _staticDataService = staticDataService;
            _gameFactory = gameFactory;
            _sceneService = sceneService;
        }

        public void Tick()
        {
            _stateMachine.Update();
        }

        public void Initialize()
        {
            InitGameStateMachine();
        }

        private void InitGameStateMachine()
        {
            _stateMachine.AddState(
                new BootstrapSceneLoadState(_stateMachine, _sceneService),
                new MainMenuState(_stateMachine, _sceneService),
                new LoadGameState(_stateMachine, _sceneService, _gameFactory, _popupFactory, _assetProvider, _staticDataService),
                new GameLoopState(_stateMachine, _gameFactory),
                new LostState(_stateMachine, _gameFactory, _popupFactory),
                new WinState(_stateMachine, _gameFactory, _levelIndexService, _popupFactory));
                
            _stateMachine.SetState<BootstrapSceneLoadState>();
        }

        public void LoadMainMenu()
        {
            _popupFactory.CleanUp();
            _gameFactory.CleanUp();
            _stateMachine.SetState<MainMenuState>();
        }
        
        public void LoadCurrentLevel()
        {
            _popupFactory.CleanUp();
            _gameFactory.CleanUp();
            _stateMachine.SetState<LoadGameState, int>(_levelIndexService.LevelIndex);
        }
    }
}
