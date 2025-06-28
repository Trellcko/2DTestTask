using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class WinState : BaseStateWithoutPayload
    {
        private readonly IGameFactory _gameFactory;
        private readonly ILevelIndexService _levelIndexService;
        private readonly IPopupFactory _popupFactory;

        public WinState(StateMachine machine, IGameFactory gameFactory, ILevelIndexService levelIndexService, IPopupFactory popupFactory) : base(machine)
        {
            _popupFactory = popupFactory;
            _levelIndexService = levelIndexService;
            _gameFactory = gameFactory;
        }

        public override void Enter()
        {
            _levelIndexService.SetLevelIndex(_levelIndexService.LevelIndex + 1);
            _popupFactory.GetPopup(PopupType.WinPopup);
        }
    }
}