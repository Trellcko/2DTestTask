using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
      
        private DiContainer _container;

        [Inject]
        public GameFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

 
        


        public void CleanUp()
        {
            _assetProvider.CleanUp();
        }



    }
}