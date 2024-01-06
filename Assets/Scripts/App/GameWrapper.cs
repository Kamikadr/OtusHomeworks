using System.Collections.Generic;
using App.ConstructTasks;
using GameEngine;
using UnityEngine;
using Zenject;

namespace App
{
    public class GameWrapper: MonoBehaviour
    {
        private DiContainer _gameContainer;

        [SerializeField] private List<ConstructTask> constructTasks;

        [Inject]
        private void Construct(DiContainer gameContainer)
        {
            _gameContainer = gameContainer;
        }
        public void ConstructGame()
        {
            foreach (var constructTask in constructTasks)
            {
                constructTask.Construct(_gameContainer);
            }
        }
        public T GetService<T>()
        {
            return _gameContainer.Resolve<T>();
        }
    }
}