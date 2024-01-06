using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Common;
using Cysharp.Threading.Tasks;

namespace App
{
    public class GameRepository: IGameRepository
    {
        private readonly FileEncryptor _fileEncryptor;
        private Dictionary<string, string> _dataCollection = new();


        public GameRepository(FileEncryptor fileEncryptor)
        {
            _fileEncryptor = fileEncryptor;
        }
        public bool TryGetData<T>(out T value)
        {
            var dataKey = typeof(T).Name;
            if (_dataCollection.TryGetValue(dataKey, out var valueData))
            {
                value = JsonConvert.DeserializeObject<T>(valueData);
                return true;
            }

            value = default;
            return false;
        }

        public void SetData<T>(T value)
        {
            var dataKey = typeof(T).Name;
            var rawData = JsonConvert.SerializeObject(value);
            
            _dataCollection[dataKey] = rawData;
        }

        public async UniTask LoadStateAsync()
        {
            if (PlayerPrefs.HasKey("save"))
            {
                var encryptedDataCollection = PlayerPrefs.GetString("save");
                var rawDataCollection = await _fileEncryptor.DecryptAsync(encryptedDataCollection);
                _dataCollection = JsonConvert.DeserializeObject<Dictionary<string,string>>(rawDataCollection);
                Debug.Log($"Repository is loaded from player prefs");
            }
        }

        public async UniTask SaveStateAsync()
        {
            var rawDataCollection = JsonConvert.SerializeObject(_dataCollection);
            var encryptedDataCollection = await _fileEncryptor.EncryptAsync(rawDataCollection);
            PlayerPrefs.SetString("save" ,encryptedDataCollection);
            Debug.Log($"Repository is saved to player prefs");
        }
    }
}