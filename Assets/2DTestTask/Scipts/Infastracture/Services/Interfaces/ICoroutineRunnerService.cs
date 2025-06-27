using System.Collections;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure
{
    public interface ICoroutineRunnerService
    {
        Coroutine StartCoroutine(IEnumerator name);
    }
}