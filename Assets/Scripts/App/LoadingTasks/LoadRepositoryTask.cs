using System;
using UnityEngine;
using Zenject;

namespace App.LoadingTasks
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
        public override async void Do(Action<Result> callback)
        {
            await _gameRepository.LoadStateAsync();
            callback.Invoke(Result.Success());
        }
    }
}