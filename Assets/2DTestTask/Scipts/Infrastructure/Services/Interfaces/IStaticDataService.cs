using System.Threading.Tasks;
using Trell.TwoDTestTask.Gameplay.Bullets;
using Trell.TwoDTestTask.Gameplay.Enemy;
using Trell.TwoDTestTask.Gameplay.Level;
using Trell.TwoDTestTask.Gameplay.Player;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IStaticDataService
    {
        Task<PlayerData> GetPlayerData();
        Task<BulletData> GetBulletData();
        Task<EnemyData> GetEnemyData(EnemyType enemyType);
        Task<LevelData> GetLevelData(int level);
    }
}