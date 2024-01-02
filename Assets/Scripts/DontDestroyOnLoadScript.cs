using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DontDestroyOnLoadScript: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}