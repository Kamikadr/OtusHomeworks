using System;
using System.Collections.Generic;
using UnityEngine;
using ViewModels;
using UniRx;

namespace Views
{
    public class CharacterInfoView: BaseView<ICharacterInfoViewModel>
    {
        [SerializeField] private Transform statContainer;

        private Dictionary<CharacterStatViewModel, CharacterStatView> _viewCollection;
        private ViewPool<CharacterStatView> _viewFactory;

        protected override void OnInitialize()
        {
            Model.CharacterStatViewModels.ObserveAdd().Subscribe(OnItemAdded).AddTo(Disposables);
            Model.CharacterStatViewModels.ObserveRemove().Subscribe(OnItemRemoved).AddTo(Disposables);
        }
        
        private void OnItemAdded(CollectionAddEvent<CharacterStatViewModel> viewModel)
        {
            var newStatView = _viewFactory.Get(statContainer);
            newStatView.Initialize(viewModel.Value);
            
            _viewCollection.Add(viewModel.Value, newStatView);
        }
        private void OnItemRemoved(CollectionRemoveEvent<CharacterStatViewModel> viewModel)
        {
            if (_viewCollection.Remove(viewModel.Value, out var value))
            {
                _viewFactory.Release(value);
            }
        }
    }
}