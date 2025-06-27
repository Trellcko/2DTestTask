using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Installer
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneService();
            BindAssetProvider();
            BindStaticDataService();
            BindGameFactory();
            BindLevelIndexService();
            BindGameBehaiour();
        }

        private void BindLevelIndexService()
        {
            Container.Bind<ILevelIndexService>()
                .To<LevelIndexService>()
                .AsSingle();
        }

        private void BindGameBehaiour()
        {
            Container.BindInterfacesTo<GameBehaviour>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container.Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindSceneService()
        {
            Container.Bind<ISceneService>()
                .To<SceneService>()
                .AsSingle();
        }
    }
}