using System;
using Constants;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure
{
    public interface ISceneService
    {
        public void Load(SceneName sceneName, Action onLoaded = null);
        string CurrentScene { get; }
    }
}