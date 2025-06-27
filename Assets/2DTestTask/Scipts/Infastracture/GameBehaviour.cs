using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.States;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure
{
    public class GameBehaviour : IGameBehaviour, ITickable, IInitializable
    {
        private readonly StateMachine _stateMachine = new();

        private ISceneService _sceneService;
        private IGameFactory _gameFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(ISceneService sceneService, IGameFactory gameFactory, IStaticDataService staticDataService)
        {
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
                new LoadGameState(_stateMachine, _sceneService, _gameFactory),
                new GameLoopState(_stateMachine, _gameFactory, _staticDataService),
                new LostState(_stateMachine, _gameFactory),
                new WinState(_stateMachine, _gameFactory));
                
            _stateMachine.SetState<BootstrapSceneLoadState>();
        }

        public void ReloadGame()
        {
            _stateMachine.SetState<LoadGameState>();
        }
    }
}
