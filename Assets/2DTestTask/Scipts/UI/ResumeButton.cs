using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.UI
{
    public class ResumeButton : ButtonWrapper
    {
        [SerializeField] private GameObject _popup;
        
        private IPauseService _pauseService;

        [Inject]
        private void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
        }
        
        protected override void InvokeClickLogic()
        {
            _pauseService.Resume();
            Destroy(_popup);
        }
    }
}
