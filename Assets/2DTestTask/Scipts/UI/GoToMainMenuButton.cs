using Trell.TwoDTestTask.Infrastructure;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.UI
{
    public class GoToMainMenuButton : ButtonWrapper
    {
        private IGameBehaviour _gameBehaviour;

        [Inject]
        private void Construct(IGameBehaviour gameBehaviour)
        {
            _gameBehaviour = gameBehaviour; 
        }
        
        protected override void InvokeClickLogic()
        {
            _gameBehaviour.LoadMainMenu();
        }
    }
}