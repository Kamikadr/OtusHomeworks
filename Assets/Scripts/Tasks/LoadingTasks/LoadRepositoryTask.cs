using System;
using GameEngine;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Tasks.LoadingTasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/LoadRepositoryTask", fileName = "LoadRepositoryTask")]
    public class LoadRepositoryTask: LoadingTask
    {
        private GameRepository _gameRepository;
        
        [Inject]
        private void Construct(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public override void Do(Action<Result> callback)
        {
            _gameRepository.LoadState();
            callback.Invoke(Result.Success());
        }
    }
}