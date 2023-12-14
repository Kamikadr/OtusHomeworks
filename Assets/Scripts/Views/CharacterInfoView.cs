using System;
using System.Collections.Generic;
using UnityEngine;
using ViewModels;
using UniRx;
using Zenject;

namespace Views
{
    public class CharacterInfoView: BaseView<ICharacterInfoViewModel>
    {
        [SerializeField] private Transform statContainer;
        [SerializeField] private int poolItemCount;

        private readonly Dictionary<CharacterStatViewModel, CharacterStatView> _viewCollection  = new();
        private ViewPool<CharacterStatView> _viewPool;

        [Inject]
        private void Construct(ViewPool<CharacterStatView> viewPool)
        {
            _viewPool = viewPool;
        }
        private void Awake()
        {
            _viewPool.Initialize(poolItemCount);
        }

        protected override void OnInitialize()
        {
            if (_viewCollection.Count != 0)
            {
                ClearStatContainer();
                _viewCollection.Clear();
            }

            for (int i = 0; i <  Model.CharacterStatViewModels.Count; i++)
            {
                AddView(Model.CharacterStatViewModels[i]);
            }
            Model.CharacterStatViewModels.ObserveAdd().Subscribe(OnItemAdded).AddTo(Disposables);
            Model.CharacterStatViewModels.ObserveRemove().Subscribe(OnItemRemoved).AddTo(Disposables);
        }
        
        private void ClearStatContainer()
        {
            foreach (CharacterStatView view in statContainer)
            {
                _viewPool.Release(view);
            }
        }

        private void OnItemAdded(CollectionAddEvent<CharacterStatViewModel> viewModel)
        {
            AddView(viewModel.Value);
        }
        private void OnItemRemoved(CollectionRemoveEvent<CharacterStatViewModel> viewModel)
        {
            RemoveView(viewModel.Value);
        }
        
        private void AddView(CharacterStatViewModel viewModel)
        {
            var newStatView = _viewPool.Get(statContainer);
            newStatView.Initialize(viewModel);
            
            _viewCollection.Add(viewModel, newStatView);
        }
        private void RemoveView(CharacterStatViewModel viewModel)
        {
            if (_viewCollection.Remove(viewModel, out var value))
            {
                _viewPool.Release(value);
            }
        }
    }
}