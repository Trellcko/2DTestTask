using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class LostState : BaseStateWithoutPayload
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPopupFactory _popupFactory;

        public LostState(StateMachine machine, IGameFactory gameFactory, IPopupFactory popupFactory) : base(machine)
        {
            _popupFactory = popupFactory;
            _gameFactory = gameFactory;
        }

        public override void Enter()
        {
            _popupFactory.GetPopup(PopupType.LosePopup);
        }

        public override void Exit()
        {

        }
    }
}