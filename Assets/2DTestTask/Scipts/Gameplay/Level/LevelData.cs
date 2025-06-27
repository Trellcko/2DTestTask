using System;
using System.Collections.Generic;
using Trell.TwoDTestTask.Gameplay.Enemy;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Trell.TwoDTestTask.Gameplay.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Gameplay/LevelData")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public Vector3 PlayerPosition { get; private set; }
        [field: SerializeField] public AssetReference LevelPrefab { get; private set; }
        [field: SerializeField] public List<EnemyConfig> EnemyConfig { get; private set; } 
    }

    [Serializable]
    public class EnemyConfig
    {
        [field: SerializeField] public Vector3 SpawnPosition { get; private set; }
        [field: SerializeField] public Vector3[] Positions { get; private set; }

        [field: SerializeField] public EnemyType Type { get; private set; }
    }
}
