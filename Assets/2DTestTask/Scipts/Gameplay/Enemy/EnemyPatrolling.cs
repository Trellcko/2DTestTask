using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Enemy
{
    public class EnemyPatrolling : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Vector3[] _patrollingPositions;

        private int _index;
        
        public void Init(Vector3[] patrollingPositions)
        {
            _patrollingPositions = patrollingPositions;
            UpdateDirection();
        }

        private void Update()
        {
            if((_patrollingPositions[_index] - transform.position).sqrMagnitude < 1)
            {
                _index = (int)Mathf.Repeat(_index + 1, _patrollingPositions.Length);
                UpdateDirection();
            }
        }

        private void UpdateDirection()
        {
            _enemyMovement.SetDirection((_patrollingPositions[_index] - transform.position).normalized);
        }
    }
}
