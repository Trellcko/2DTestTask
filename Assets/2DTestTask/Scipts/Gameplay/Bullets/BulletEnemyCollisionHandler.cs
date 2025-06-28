using System;
using Trell.TwoDTestTask.Gameplay.Enemy;
using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Bullet
{
    public class BulletEnemyCollisionHandler : MonoBehaviour
    {
        [SerializeField] private BulletCollisionEventInvoker _collisionEventInvoker;

        public static event Action EnemyKilled;
        
        private void OnEnable()
        {
            _collisionEventInvoker.EnemyCollided += OnEnemyCollided;
        }

        private void OnDisable()
        {
            _collisionEventInvoker.EnemyCollided -= OnEnemyCollided;
        }

        private void OnEnemyCollided(EnemyFacade obj)
        {
            Destroy(obj.gameObject);
            EnemyKilled?.Invoke();
            Destroy(transform.parent.gameObject);
        }
    }
}
