using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Bullet
{
    public class BulletGroundCollisionHandler : MonoBehaviour
    {
        [SerializeField] private BulletCollisionEventInvoker _bulletCollisionEventInvoker;

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
            Destroy(transform.parent.gameObject);
        }
    }
}