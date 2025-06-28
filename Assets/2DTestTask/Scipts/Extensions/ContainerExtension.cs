using System.Linq;
using Zenject;

namespace Trell.TwoDTestTask.Extension
{
    public static class ContainerExtension
    {
        public static DiContainer GetSceneContextContainer() =>
            ProjectContext.Instance.Container
                .Resolve<SceneContextRegistry>()
                .SceneContexts.LastOrDefault()?.Container 
            ?? ProjectContext.Instance.Container;
    }
}