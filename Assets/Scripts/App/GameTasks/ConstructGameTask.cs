using System;
using UnityEngine;
using Zenject;

namespace App.GameTasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/ConstructGameTask", fileName = "Construct Game Task")]
    public sealed class ConstructGameTask: LoadingTask
    {
        private GameFacade _gameFacade;

        [Inject]
        private void Construct(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }
        public override void Do(Action<Result> callback)
        {
            _gameFacade.ConstructGame();
            callback.Invoke(Result.Success());
        }
    }
}