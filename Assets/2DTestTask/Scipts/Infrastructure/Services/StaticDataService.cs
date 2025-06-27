using System.Threading.Tasks;
using Constants;
using Trell.TwoDTestTask.Gameplay.Bullets;
using Trell.TwoDTestTask.Gameplay.Enemy;
using Trell.TwoDTestTask.Gameplay.Level;
using Trell.TwoDTestTask.Gameplay.Player;
using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure
{
    public class StaticDataService : IStaticDataService
    {

        private readonly IAssetProvider _assetProvider;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<LevelData> GetLevelData(int level)
        {
            return (LevelData) await _assetProvider.Load<ScriptableObject>(AddressableNames.LevelData + level);
        }
        public async Task<EnemyData> GetEnemyData(EnemyType enemyType)
        {
            return (EnemyData)await _assetProvider.Load<ScriptableObject>(enemyType + AddressableNames.EnemyData);
        }
        
        public async Task<PlayerData> GetPlayerData()
        {
            return (PlayerData)await _assetProvider.Load<ScriptableObject>(AddressableNames.PlayerData);
        }

        public async Task<BulletData> GetBulletData()
        {
            return (BulletData) await _assetProvider.Load<ScriptableObject>(AddressableNames.BulletData);
        }
    }
}