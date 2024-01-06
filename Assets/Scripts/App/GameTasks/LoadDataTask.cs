using System;
using System.Collections.Generic;
using App.SaveSystem.Interfaces;
using UnityEngine;
using Zenject;

namespace App.GameTasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/SaveLoadTask", fileName = "Save Load Task")]
    public sealed class LoadDataTask: LoadingTask
    {
        private IEnumerable<ISaveLoader> _saveLoaders;
        private IGameRepository _gameRepository;
        
        [Inject]
        private void Construct(IEnumerable<ISaveLoader> saveLoaders, IGameRepository gameRepository)
        {
            _saveLoaders = saveLoaders;
            _gameRepository = gameRepository;
        }
        public override void Do(Action<Result> callback)
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadData(_gameRepository);
            }

            callback.Invoke(Result.Success());
        }
    }
}