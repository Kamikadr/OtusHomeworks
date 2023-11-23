using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Common
{
    public class Factory<T>: MonoBehaviour where T:MonoBehaviour
    {
        [SerializeField] private  T prefabItem;
        

        public  T Create(Transform parent)
        {
            var item = Instantiate(prefabItem, parent);
            return item;
        }
        
    }
}