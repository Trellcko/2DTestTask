using Constants;
using Trell.TwoDTestTask.Infrastructure.States;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class MainMenuState : BaseStateWithoutPayload
    {
        private ISceneService _sceneService;

        public MainMenuState(StateMachine machine, ISceneService sceneService) : base(machine)
        {
            _sceneService = sceneService;
        }

        public override void Enter()
        {
            _sceneService.Load(SceneName.MainMenuScene);
        }
    }
}