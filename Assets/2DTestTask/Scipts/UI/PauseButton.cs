using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using Zenject;

namespace Trell.TwoDTestTask.UI
{
    public class PauseButton : ButtonWrapper
    {
        private IPopupFactory _factory;
        private IPauseService _pauseService;

        [Inject]
        private void Construct(IPopupFactory popupFactory, IPauseService pauseService)
        {
            _pauseService = pauseService;
            _factory = popupFactory;
        }

        protected override void InvokeClickLogic()
        {
            _factory.GetPopup(PopupType.PausePopup);
            _pauseService.Pause();
        }
    }
}
