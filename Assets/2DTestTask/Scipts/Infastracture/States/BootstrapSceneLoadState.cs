using Constants;
using Trell.TwoDTestTask.Infrastructure.States;

namespace Trell.TwoDTestTask.Infrastructure
{
    public class BootstrapSceneLoadState : BaseStateWithoutPayload
    {
        private readonly ISceneService _sceneService;

        public BootstrapSceneLoadState(StateMachine machine, ISceneService sceneService) : base(machine)
        {
            _sceneService = sceneService;
        }

        public override void Enter()
        {
            _sceneService.Load(SceneName.BootstrapScene, GoToState<MainMenuState>);
        }
    }
}