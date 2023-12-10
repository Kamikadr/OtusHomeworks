using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Common
{
    public class Factory<T> where T:MonoBehaviour
    {
        private readonly T _prefabItem;
        private readonly LifetimeScope _parentScope;
        private readonly IObjectResolver _resolver;

        public Factory(T prefabItem, LifetimeScope parentScope, IObjectResolver resolver)
        {
            _prefabItem = prefabItem;
            _parentScope = parentScope;
            _resolver = resolver;
        }

        public  T Create(Transform parent)
        {
            using (LifetimeScope.EnqueueParent(_parentScope))
            {
                var item = Object.Instantiate(_prefabItem, parent);

                return item;
            }
            //var item = Object.Instantiate(_prefabItem, parent);

            //return item;
        }
    }
}