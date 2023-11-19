﻿using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class Factory<T> where T:MonoBehaviour
    {
        private readonly T _prefabItem;

        public Factory(T prefabItem)
        {
            _prefabItem = prefabItem;
        }

        public  T Create(Transform parent)
        {
            var item = Object.Instantiate(_prefabItem, parent);
            OnCreate(item);
            return item;
        }

        protected virtual void OnCreate(T item)
        {
        }
    }
}