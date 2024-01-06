using System.Collections.Generic;
using SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public sealed class SaveHelper : MonoBehaviour
{
    private IEnumerable<ISaveLoader> _saveLoaders;
    private IGameRepository _gameRepository;
    private GameSaver _gameSaver;
    [Inject]
    private void Construct(IEnumerable<ISaveLoader> saveLoaders, IGameRepository gameRepository, GameSaver gameSaver)
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
    public void SaveStates()
    {
        _gameSaver.SaveStates();
    }
}