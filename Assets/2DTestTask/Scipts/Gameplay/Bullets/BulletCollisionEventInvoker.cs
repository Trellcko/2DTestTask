using System;
using UnityEngine;
using Zenject.SpaceFighter;

namespace Trell.TwoDTestTask.Gameplay.Bullet
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletCollisionEventInvoker : MonoBehaviour
    {
        public event Action GroundCollided;
        public event Action<EnemyFacade> EnemyCollided;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ground _))
            {
                GroundCollided?.Invoke();
            }
            else if(other.gameObject.TryGetComponent(out EnemyFacade enemy))
            {
                EnemyCollided?.Invoke(enemy);
            }
        }
    }
}
