using System.Collections;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface ICoroutineRunnerService
    {
        Coroutine StartCoroutine(IEnumerator name);
    }
}