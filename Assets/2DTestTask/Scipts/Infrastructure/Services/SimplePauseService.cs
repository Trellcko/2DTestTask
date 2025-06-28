using System;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public class SimplePauseService : IPauseService, IDisposable
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0;
        }

        public void Resume()
        {
            IsPaused = false;
            Time.timeScale = 1;
        }

        public void Dispose()
        {
            Resume();
        }
    }
}
