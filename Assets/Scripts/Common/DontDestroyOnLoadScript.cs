using UnityEngine;

namespace Common
{
    public sealed class DontDestroyOnLoadScript: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}