using UnityEngine;

namespace Trell
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private float _speed;
        private int _direction;

        public void Init(float speed, int direction)
        {
            _speed = speed;
            _direction = direction;
            
            _rigidbody2D.velocity = _speed * _direction * Vector2.right;
        }
    }
}
