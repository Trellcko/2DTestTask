using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Trell.TwoDTestTask.Gameplay.Bullets
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Gameplay/BulletData", order = 0)]
    public class BulletData : ScriptableObject
    {
        [field: SerializeField] public AssetReference Prefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
    }
}