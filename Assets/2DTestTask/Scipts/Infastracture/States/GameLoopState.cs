using Trell.TwoDTestTask.Infrastructure.Factories;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class GameLoopState : BaseStateWithoutPayload
    {

        private readonly IStaticDataService _staticDataService;
        private readonly IGameFactory _gameFactory;

        public GameLoopState(StateMachine machine, IGameFactory gameFactory, IStaticDataService staticDataService) :
            base(machine)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }

        public override void Enter()
        {
          
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
        }

    }
}