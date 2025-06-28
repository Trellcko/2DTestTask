using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trell.TwoDTestTask.Extension;
using Trell.TwoDTestTask.Gameplay.Bullets;
using Trell.TwoDTestTask.Gameplay.Bullet;
using Trell.TwoDTestTask.Gameplay.Enemy;
using Trell.TwoDTestTask.Gameplay.Player;
using Trell.TwoDTestTask.Infrastructure.AssetManagment;
using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Trell.TwoDTestTask.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
      
        private DiContainer _container;
        public PlayerFacade PlayerFacade { get; private set; }

        public IReadOnlyList<EnemyFacade> SpawnedEnemies => _spawnedEnemies;
        public IReadOnlyList<BulletFacade> SpawnedBullets => _spawnedBullets;
        
        private readonly List<EnemyFacade> _spawnedEnemies = new();
        private readonly List<BulletFacade> _spawnedBullets = new();

        [Inject]
        public GameFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public event Action<PlayerFacade> PlayerCreated;

        public void RefreshContainer()
        {
            _container = ContainerExtension.GetSceneContextContainer();
        }

        
        
        public async Task<EnemyFacade> CreateEnemy(EnemyType enemyType, Vector2 position, Vector3[] patrolsPositions)
        {
            EnemyData enemyData = await _staticDataService.GetEnemyData(enemyType);
            GameObject prefab = await _assetProvider.Load<GameObject>(enemyData.Prefab);
            EnemyFacade spawned = Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<EnemyFacade>();            
            _container.InjectGameObject(spawned.gameObject);
            spawned.EnemyMovement.Init(enemyData.Speed);
            spawned.EnemyPatrolling.Init(patrolsPositions);
            spawned.EnemyChasing.Init(enemyData.ChasingRadius);
            _spawnedEnemies.Add(spawned);
            return spawned;

        }

        public async Task<BulletFacade> CreateBullet(Vector2 position, int direction)
        {
            BulletData playerData = await _staticDataService.GetBulletData();
            GameObject prefab = await _assetProvider.Load<GameObject>(playerData.Prefab);
            BulletFacade spawned = Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<BulletFacade>();
            _container.InjectGameObject(spawned.gameObject);
            spawned.BulletMovement.Init(playerData.Speed, direction);
            _spawnedBullets.Add(spawned);
            return spawned;
        }
        
        public async Task<PlayerFacade> CreatePlayer(Vector2 position)
        {
            PlayerData playerData = await _staticDataService.GetPlayerData();
            GameObject prefab = await _assetProvider.Load<GameObject>(playerData.PlayerPrefab);
            PlayerFacade spawned = Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<PlayerFacade>();
            _container.InjectGameObject(spawned.gameObject);
            spawned.PlayerMovement.Init(playerData.Speed, playerData.JumpForce);
            spawned.PlayerShooting.Init(playerData.BulletCount);
            PlayerFacade = spawned;
            PlayerCreated?.Invoke(spawned);
            return spawned;
        }

        public void CleanUp()
        {
            _spawnedBullets.Clear();
            _spawnedEnemies.Clear();
            _assetProvider.CleanUp();
        }



    }
}