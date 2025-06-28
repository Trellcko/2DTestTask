using TMPro;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.UI
{
    public class LevelLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        
        private ILevelIndexService _levelIndexService;

        [Inject]
        private void Construct(ILevelIndexService levelIndexService)
        {
            _levelIndexService = levelIndexService;
            _textMeshProUGUI.SetText("Level " + _levelIndexService.LevelValue);
        }
    }
}
