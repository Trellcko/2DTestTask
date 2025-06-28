using System;
using System.Collections;
using System.Collections.Generic;
using Trell.TwoDTestTask.Gameplay.Enemy;
using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Player
{
[RequireComponent(typeof(Collider2D))]
    public class PlayerCollisionEventInvoker : MonoBehaviour
    {
        public event Action<EnemyFacade> EnemyCollided;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out EnemyFacade enemyFacade))
            {
                EnemyCollided?.Invoke(enemyFacade);
            }
        }
    }
}
