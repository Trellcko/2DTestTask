using System;
using Trell.TwoDTestTask.Infrastructure.Factories;
using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Gameplay.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        
        private IGameFactory _gameFactory;
        private IPlayerInputService _playerInputService;

        public int MaxBulletCount { get; private set; } = 3;
        public int CurrentBulletCount { get; private set; }

        public event Action CurrentBulletCountChanged; 
        
        [Inject]
        private void Construct(IGameFactory gameFactory, IPlayerInputService playerInputService)
        {
            _gameFactory = gameFactory;
            _playerInputService = playerInputService;
            Subscribe();
        }

        public void Init(int bulletCount)
        {
            CurrentBulletCount = MaxBulletCount = bulletCount;
        }

        private void OnEnable()
        {
            if (_playerInputService != null)
                Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void UnSubscribe()
        {
            _playerInputService.FireButtonClicked -= OnFireButtonClicked;
        }

        private void Subscribe()
        {
            _playerInputService.FireButtonClicked += OnFireButtonClicked;
        }

        private void OnFireButtonClicked()
        {
            if(CurrentBulletCount < 1)
                return;
            _gameFactory.CreateBullet(_shootPoint.position, -(int)transform.parent.localScale.x);
            CurrentBulletCount--;
            CurrentBulletCountChanged?.Invoke();
        }
    }
}
