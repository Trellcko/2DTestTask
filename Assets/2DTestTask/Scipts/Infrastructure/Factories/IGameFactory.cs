using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trell.TwoDTestTask.Gameplay.Bullet;
using Trell.TwoDTestTask.Gameplay.Enemy;
using Trell.TwoDTestTask.Gameplay.Player;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Factories
{
    public interface IGameFactory : IFactory
    {
        public PlayerFacade PlayerFacade { get; }
        IReadOnlyList<EnemyFacade> SpawnedEnemies { get; }
        public event Action<PlayerFacade> PlayerCreated;
        
        public Task<PlayerFacade> CreatePlayer(Vector2 position); 
        Task<BulletFacade> CreateBullet(Vector2 position, int direction);
        Task<EnemyFacade> CreateEnemy(EnemyType enemyType, Vector2 position, Vector3[] patrolsPositions);
    }
}