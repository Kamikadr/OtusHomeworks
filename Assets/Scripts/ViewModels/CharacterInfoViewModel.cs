using System;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using UniRx;


namespace ViewModels
{
    public class CharacterInfoViewModel: ICharacterInfoViewModel, IDisposable
    {
        public IReadOnlyReactiveCollection<CharacterStatViewModel> CharacterStatViewModels => _characterStatViewModels;
        
        private readonly CharacterInfo _characterInfo;
        private readonly Dictionary<CharacterStat, CharacterStatViewModel> _characterStatViewModelsCollection = new();
        private readonly ReactiveCollection<CharacterStatViewModel> _characterStatViewModels = new();


        public CharacterInfoViewModel(CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;

            _characterInfo.OnStatAdded += AddStat;
            _characterInfo.OnStatRemoved += RemoveStat;
            
            var existedStats = characterInfo.GetStats();
            for (var i = 0; i < existedStats.Length; i++)
            {
                AddStat(existedStats[i]);
            }
        }
        private void AddStat(CharacterStat obj)
        {
            var statViewModel = new CharacterStatViewModel(obj);
            if (_characterStatViewModelsCollection.TryAdd(obj, statViewModel))
            {
                _characterStatViewModels.Add(statViewModel);
            }
            else
            {
                throw new Exception($"{obj} is already exist in Collection");
            }
        }
        private void RemoveStat(CharacterStat obj)
        {
            if (_characterStatViewModelsCollection.Remove(obj, out var removedItem))
            {
                removedItem.Dispose();
                _characterStatViewModels.Remove(removedItem);
            }
            else
            {
                throw new Exception($"Collection hasn't got {obj} to remove that");
            }
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= AddStat;
            _characterInfo.OnStatRemoved -= RemoveStat;
            
            _characterStatViewModels?.Dispose();
        }
    }
}