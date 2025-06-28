using System.Collections.Generic;
using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Level
{
    [CreateAssetMenu(fileName = "LevelsDataList", menuName = "Gameplay/LevelDataList")]
    public class LevelDataList : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelData;
        
        public IReadOnlyList<LevelData> LevelData => _levelData;
    }
}
