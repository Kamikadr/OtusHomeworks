using System;
using System.Collections.Generic;
using DefaultNamespace;
using GameEngine;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Tasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/ConstructGameTask", fileName = "Construct Game Task")]
    public class ConstructGameTask: LoadingTask
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