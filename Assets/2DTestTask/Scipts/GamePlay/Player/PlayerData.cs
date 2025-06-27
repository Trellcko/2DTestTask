using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Trell.TwoDTestTask.Gameplay.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Gameplay/Player", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public AssetReference PlayerPrefab { get; private set; }
        [field: SerializeField] public int BulletCount { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public float JumpForce { get; set; }
    }
}