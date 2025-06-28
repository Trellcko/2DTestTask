using Constants;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Gameplay.Enemy
{
    public class EnemyChasing : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyPatrolling _enemyPatrolling;

        private IGameFactory _gameFactory;
        private IPhysicCheckService _physicCheckService;

        private Transform Target => _gameFactory.PlayerFacade.transform;

        private float _checkRadius;
        private bool _isTargetNoticed;

        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _checkRadius);
        }

        #endregion

        [Inject]
        private void Construct(IGameFactory gameFactory, IPhysicCheckService physicCheckService)
        {
            _physicCheckService = physicCheckService;
            _gameFactory = gameFactory;
        }

        public void Init(float checkRadius)
        {
            _checkRadius = checkRadius;
        }

        private void Update()
        {
            if(_isTargetNoticed)
                _enemyMovement.SetDirection((Target.position - transform.position).normalized);
        }

        private void FixedUpdate()
        {
            if (Target && !_isTargetNoticed)
            {
                if (!_physicCheckService.CheckForObstacleBetweenObjects
                        (transform.position, Target.position, _checkRadius, LayerNames.GroundLayer))
                {
                    _enemyPatrolling.enabled = false;
                    _isTargetNoticed = true;
                }
            }
        }
    }
}
