using Trell.TwoDTestTask.Gameplay.Level;
using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Factories;

namespace Trell.TwoDTestTask.Infrastructure.Services
{
    public class LevelInitializerService : ILevelInitializerService
    {
        private IGameFactory _gameFactory;
        private IAssetProvider _assetProvider;

        public LevelInitializerService(IGameFactory gameFactory, IAssetProvider assetProvider)
        {
            _gameFactory = gameFactory;
            _assetProvider = assetProvider;
        }
        
        public void InitializeLevel(LevelData levelData)
        {
            
        }
    }

    public interface ILevelInitializerService
    {
        void InitializeLevel(LevelData levelData);
    }
}