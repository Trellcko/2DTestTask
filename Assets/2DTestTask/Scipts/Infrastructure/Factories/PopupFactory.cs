using System.Threading.Tasks;
using Trell.TwoDTestTask.Extension;
using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Factories
{
    public class PopupFactory : IPopupFactory
    {
        private readonly IAssetProvider _assetProvider;
        private DiContainer _container;

        public PopupFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _container = container;
            _assetProvider = assetProvider;
        }
        
        public async Task<GameObject> GetPopup(PopupType popupType)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(popupType.ToString());
            GameObject spawned = Object.Instantiate(prefab);
            _container.InjectGameObject(spawned);
            
            return spawned;
        }

        public void CleanUp()
        {
            _assetProvider.CleanUp();
        }

        public void RefreshContainer()
        {
            _container = ContainerExtension.GetSceneContextContainer();
        }
    }

    public enum PopupType
    {
        WinPopup,
        LosePopup,
        PausePopup,
    }
}