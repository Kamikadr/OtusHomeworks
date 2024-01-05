using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using GameEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Object = System.Object;

namespace Tasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/LoadSceneTask", fileName = "LoadSceneTask")]
    public class LoadSceneTask: LoadingTask
    {
        private GameFacade _gameFacade;
        private const string GameSceneName = "GameScene";

        [Inject]
        private void Construct(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }
        public override async void Do(Action<Result> callback)
        {
            await LoadScene();
            var gameWrapper = FindObjectOfType<GameWrapper>();
            _gameFacade.SetupGameContext(gameWrapper);
            callback.Invoke(Result.Success());
        }
        
        
        private IEnumerator LoadScene()
        {
            var operation = SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Single);
            while (!operation.isDone)
            {
                var p = operation.progress;
                yield return null;
            }
            
        }
    }
}