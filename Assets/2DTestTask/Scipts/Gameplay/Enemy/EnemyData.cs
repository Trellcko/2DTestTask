using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Trell.TwoDTestTask.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "GamePlayEnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public AssetReference Prefab { get; private set; } 
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float ChasingRadius {get; private set;}
    }
}