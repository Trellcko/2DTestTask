using System;
using TMPro;
using Trell.TwoDTestTask.Gameplay.Player;
using Trell.TwoDTestTask.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Service.UI
{
    public class BulletCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private IGameFactory _gameFactory;

        private PlayerShooting _playerShooting;
        
        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            if (_gameFactory.PlayerFacade)
            {
                _playerShooting = _gameFactory.PlayerFacade.PlayerShooting;
                return;
            }
            _gameFactory.PlayerCreated += OnPlayerCreated;
        }

        private void OnEnable()
        {
            if (_playerShooting)
            {
                _playerShooting.CurrentBulletCountChanged += UpdateText;
            }
            else
            {
                _gameFactory.PlayerCreated += OnPlayerCreated;
            }
        }

        private void OnDisable()
        {
            if(_playerShooting)
                _playerShooting.CurrentBulletCountChanged -= UpdateText;
            
            if(_gameFactory != null)
                _gameFactory.PlayerCreated -= OnPlayerCreated;
        }

        private void OnPlayerCreated(PlayerFacade obj)
        {
            _gameFactory.PlayerCreated -= OnPlayerCreated;
            _playerShooting = obj.PlayerShooting;
            UpdateText();
            _playerShooting.CurrentBulletCountChanged += UpdateText;
        }

        private void UpdateText()
        {
            _text.SetText($"{_playerShooting.CurrentBulletCount}/{_playerShooting.MaxBulletCount}");
        }
    }
}