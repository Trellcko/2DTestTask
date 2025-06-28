using System;
using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Bullet
{
    public class BulletGroundCollisionHandler : MonoBehaviour
    {
        [SerializeField] private BulletCollisionEventInvoker _bulletCollisionEventInvoker;

        public static event Action DestroyedByGround;
        
        private void OnEnable()
        {
            _bulletCollisionEventInvoker.GroundCollided += OnGroundCollided;
        }

        private void OnDisable()
        {
            _bulletCollisionEventInvoker.GroundCollided -= OnGroundCollided;
        }

        private void OnGroundCollided()
        {
            DestroyedByGround?.Invoke();
            Destroy(transform.parent.gameObject);
        }
    }
}