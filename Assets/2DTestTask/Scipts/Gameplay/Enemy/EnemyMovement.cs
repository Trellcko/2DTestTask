using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private float _speed = 3;
        private Vector3 _direction;

        public void Init(float speed)
        {
            _speed = speed;
        }
        
        public void SetDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}