using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Service.UI
{
    public class StartGameButton : ButtonWrapper
    {
        private ILevelIndexService _levelIndexService;
        private IGameBehaviour _gameBehaviour;

        [Inject]
        private void Construct(ILevelIndexService levelIndexService, IGameBehaviour gameBehaviour)
        {
            _levelIndexService = levelIndexService;
            _gameBehaviour = gameBehaviour;
        }
        
        protected override void InvokeClickLogic()
        {
            _levelIndexService.SetLevelIndex(0);
            _gameBehaviour.LoadCurrentLevel();
        }
    }
}
