using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Infrastructure.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputService _playerInputService;
        
        public override void InstallBindings()
        {
            PlayerInputBind();
            CheckingGroundServiceBind();
        }

        private void CheckingGroundServiceBind()
        {
            Container.Bind<IOverlapCheckService>()
                .To<OverlapCheckService>()
                .AsSingle();
        }

        private void PlayerInputBind()
        {
            Container.Bind<IPlayerInputService>()
                .FromInstance(_playerInputService)
                .AsSingle();
        }
    }
}