using System.Collections.Generic;
using App;
using App.SaveSystem;
using App.SaveSystem.Interfaces;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Helpers
{ 
    public sealed class SaveHelper : MonoBehaviour
    {
        private IEnumerable<ISaveLoader> _saveLoaders;
        private IGameRepository _gameRepository;
        private GameSaver _gameSaver;

        [Inject]
        private void Construct(IEnumerable<ISaveLoader> saveLoaders, IGameRepository gameRepository,
            GameSaver gameSaver)
        {
            _saveLoaders = saveLoaders;
            _gameRepository = gameRepository;
            _gameSaver = gameSaver;
        }

        [Button]
        public void Save()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveData(_gameRepository);
            }
        }
        
        [Button]
        public void Load()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadData(_gameRepository);
            }
        }

        [Button]
        public void SaveStates()
        {
             _gameSaver.SaveStates().Forget();
        }
        
        [Button]
        public async void LoadStates()
        {
            await _gameRepository.LoadStateAsync();
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadData(_gameRepository);
            }
        }
    }
}