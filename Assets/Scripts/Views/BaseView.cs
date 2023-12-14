using System;
using UniRx;
using UnityEngine;
using ViewModels;

namespace Views
{

    public abstract class BaseView<T>: MonoBehaviour, IDisposable where T: IViewModel
    {
        protected CompositeDisposable Disposables;
        protected T Model;
        public void Initialize(T viewModel)
        {
            Disposables?.Dispose();
            Disposables = new CompositeDisposable();
            Model = viewModel;
            OnInitialize();
        }
        protected abstract void OnInitialize();

        public virtual void Dispose()
        {
            Disposables?.Dispose();
            Disposables = null;
        }
        
        protected virtual void OnDestroy()
        {
            Dispose();
        }
    }
}