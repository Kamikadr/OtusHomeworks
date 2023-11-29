using System;
using ShootEmUp.Game;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-1)]
    public class GameManagerInstaller:MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            var roots = gameObject.scene.GetRootGameObjects();
            foreach (var root in roots)
            {
                gameManager.AddListeners(root);
            }
        }
    }
}