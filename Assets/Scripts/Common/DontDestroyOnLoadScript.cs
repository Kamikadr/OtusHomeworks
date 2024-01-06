using UnityEngine;

namespace Common
{
    public class DontDestroyOnLoadScript: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}