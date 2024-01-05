using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class GameRepository: IGameRepository
    {
        private Dictionary<string, string> _dataCollection = new();


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

        public void LoadState()
        {
            if (PlayerPrefs.HasKey("save"))
            {
                var rawDataCollection = PlayerPrefs.GetString("save");
                _dataCollection = JsonConvert.DeserializeObject<Dictionary<string,string>>(rawDataCollection);
            }
        }

        public void SaveState()
        {
            var rawDataCollection = JsonConvert.SerializeObject(_dataCollection);
            PlayerPrefs.SetString("save" ,rawDataCollection);
        }
    }
}