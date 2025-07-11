using System;
using System.Collections;
using System.Threading.Tasks;
using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Service
{
    public class SceneService : ISceneService
    {
        public string CurrentScene => SceneManager.GetActiveScene().name;
        
        public async void Load(SceneName sceneName, Action onLoaded = null)
        {
            try
            {
                AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName.ToString());

                while (!waitNextScene.isDone)
                {
                    await Task.Yield();
                }

                onLoaded?.Invoke();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}