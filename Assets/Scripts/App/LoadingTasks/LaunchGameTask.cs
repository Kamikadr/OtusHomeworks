using System;
using UnityEngine;
using Zenject;

namespace App.LoadingTasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/LaunchGameTask", fileName = "LaunchGameTask")]
    public class LaunchGameTask: LoadingTask
    {
        private GameLauncher _gameLauncher;
        private DiContainer _container;
        
        [Inject]
        private void Construct(GameLauncher gameLauncher, DiContainer container)
        {
            _gameLauncher = gameLauncher;
            _container = container;
        }
        public override async void Do(Action<Result> callback)
        {
            await _gameLauncher.LaunchGame(_container);
            callback.Invoke(Result.Success());
        }
    }
}