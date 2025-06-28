using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Trell.TwoDTestTask.Gameplay.Player;
using Trell.TwoDTestTask.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _gameFactory.PlayerCreated += OnPlayerCreated;
            if (_gameFactory.PlayerFacade)
            {
                OnPlayerCreated(_gameFactory.PlayerFacade);
            }
        }

        private void OnDisable()
        {
            _gameFactory.PlayerCreated -= OnPlayerCreated;
        }

        private void OnPlayerCreated(PlayerFacade obj)
        {
            _gameFactory.PlayerCreated -= OnPlayerCreated;
            _virtualCamera.Follow = obj.transform;
        }
    }
}
