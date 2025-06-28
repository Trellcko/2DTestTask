using System;
using JetBrains.Annotations;
using Trell.TwoDTestTask.Gameplay.Enemy;
using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Player
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionEventInvoker _playerCollisionEventInvoker;
        
        public event Action Died;
        
        private void OnEnable()
        {
            _playerCollisionEventInvoker.EnemyCollided += OnEnemyCollided;
        }

        private void OnDisable()
        {
            _playerCollisionEventInvoker.EnemyCollided -= OnEnemyCollided;
        }

        private void OnEnemyCollided(EnemyFacade obj)
        {
            if(!obj.EnemyDangerLabel)
                return;
            
            _playerCollisionEventInvoker.EnemyCollided -= OnEnemyCollided;
            Died?.Invoke();
        }
    }
}