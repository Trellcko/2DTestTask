using System;
using Constants;
using Trell.TwoDTestTask.Infrastructure.Factories;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.States
{
    public class LoadGameState : BaseStateWithPayLoad<int>
    {
        private readonly ISceneService _sceneService;
        private IGameFactory _factory;

        public LoadGameState(StateMachine machine, ISceneService sceneService, IGameFactory factory) : base(machine)
        {
            _factory = factory;
            _sceneService = sceneService;
        }

        public override void  Enter(int level)
        {
            _sceneService.Load(SceneName.GameScene, OnLoaded);
            _factory.CleanUp();
        }

        private void OnLoaded()
        {
            GoToState<GameLoopState>();
        }
    }
}