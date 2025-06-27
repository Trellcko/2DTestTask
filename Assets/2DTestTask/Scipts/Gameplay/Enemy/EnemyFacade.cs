using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Enemy
{
    public class EnemyFacade : MonoBehaviour
    { 
        [field: SerializeField] public EnemyMovement EnemyMovement { get; private set; }
        [field: SerializeField] public EnemyPatrolling EnemyPatrolling { get; private set; }
    }
}