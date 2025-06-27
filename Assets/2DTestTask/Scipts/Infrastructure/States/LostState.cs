using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class LostState : BaseStateWithoutPayload
    {
        private readonly IGameFactory _gameFactory;

        public LostState(StateMachine machine, IGameFactory gameFactory) : base(machine)
        {
            _gameFactory = gameFactory;
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {

        }
    }
}