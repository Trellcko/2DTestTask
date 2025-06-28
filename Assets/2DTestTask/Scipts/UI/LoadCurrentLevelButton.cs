using Trell.TwoDTestTask.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using Zenject;

namespace Trell.TwoDTestTask.UI
{
    public class LoadCurrentLevelButton : ButtonWrapper
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
            _gameBehaviour.LoadCurrentLevel();
        }
    }
}
