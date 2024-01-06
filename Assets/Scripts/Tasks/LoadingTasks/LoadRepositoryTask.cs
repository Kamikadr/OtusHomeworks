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
        private IGameRepository _gameRepository;
        
        [Inject]
        private void Construct(IGameRepository gameRepository)
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