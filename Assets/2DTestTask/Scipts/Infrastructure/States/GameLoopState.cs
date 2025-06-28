using System.Linq;
using Trell.TwoDTestTask.Gameplay.Bullet;
using Trell.TwoDTestTask.Gameplay.Enemy;
using Trell.TwoDTestTask.Gameplay.Player;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class GameLoopState : BaseStateWithoutPayload
    {
        private readonly IGameFactory _gameFactory;

        public GameLoopState(StateMachine machine, IGameFactory gameFactory) :
            base(machine)
        {
            _gameFactory = gameFactory;
        }

        public override void Enter()
        {
            if (_gameFactory.PlayerFacade)
            {
                SubscribeToPlayer(_gameFactory.PlayerFacade);
            }
            else
            {
                _gameFactory.PlayerCreated += SubscribeToPlayer;
            }

            BulletGroundCollisionHandler.DestroyedByGround += OnBulletCountChanged;
            BulletEnemyCollisionHandler.EnemyKilled += OnEnemyDied;
        }

        private void SubscribeToPlayer(PlayerFacade player)
        {
            _gameFactory.PlayerCreated -= SubscribeToPlayer;
            player.PlayerDeathHandler.Died += OnDied;
        }

        private void OnEnemyDied()
        {
            if(_gameFactory.SpawnedEnemies.Count(x =>  x && x.enabled) == 0)
                GoToState<WinState>();
            else
            {
                OnBulletCountChanged();   
            }
        }


        private void OnDied()
        {
            GoToState<LostState>();
        }

        private void OnBulletCountChanged()
        {
            if(_gameFactory.PlayerFacade.PlayerShooting.CurrentBulletCount < 1 && 
               _gameFactory.SpawnedBullets.Count(x =>  x && x.enabled) == 1)
                GoToState<LostState>();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {   
            BulletGroundCollisionHandler.DestroyedByGround -= OnBulletCountChanged;
            _gameFactory.PlayerCreated -= SubscribeToPlayer;
            BulletEnemyCollisionHandler.EnemyKilled -= OnEnemyDied;
            _gameFactory.PlayerFacade.PlayerShooting.BulletCountChanged -= OnBulletCountChanged;
            _gameFactory.PlayerFacade.PlayerDeathHandler.Died -= OnDied;
        }

    }
}