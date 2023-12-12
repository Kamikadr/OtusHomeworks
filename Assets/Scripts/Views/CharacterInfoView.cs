using System;
using System.Collections.Generic;
using UnityEngine;
using ViewModels;
using UniRx;

namespace Views
{
    public class CharacterInfoView: MonoBehaviour
    {
        [SerializeField] private Transform statContainer;

        private Dictionary<CharacterStatViewModel, CharacterStatView> _viewCollection;
        private CharacterStatViewFactory _characterStatViewFactory;
        private ICharacterInfoViewModel _model;
        private CompositeDisposable _disposable;

        public void Initialize(object obj)
        {
            if (obj is not ICharacterInfoViewModel popupViewModel)
            {
                throw new Exception("Expected IPopupViewModel");
            }
            
            _model = popupViewModel;

            _disposable = new CompositeDisposable();
            _model.CharacterStatViewModels.ObserveAdd().Subscribe(OnItemAdded).AddTo(_disposable);
            _model.CharacterStatViewModels.ObserveRemove().Subscribe(OnItemRemoved).AddTo(_disposable);

        }
        
        private void OnItemAdded(CollectionAddEvent<CharacterStatViewModel> viewModel)
        {
            var newStatView = _characterStatViewFactory.Create(statContainer);
            newStatView.Initialize(viewModel.Value);
            
            _viewCollection.Add(viewModel.Value, newStatView);
        }
        private void OnItemRemoved(CollectionRemoveEvent<CharacterStatViewModel> viewModel)
        {
            Destroy(_viewCollection[viewModel.Value].gameObject);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}