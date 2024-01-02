using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/LoadSceneTask", fileName = "LoadSceneTask")]
    public class LoadSceneTask: LoadingTask
    {

        private const string GameSceneName = "GameScene";
        
        private void Construct()
        {
            
        }
        public override async UniTask<Result> Do()
        {
            await LoadScene();

            return LoadingTask.Result.Success();
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

    public class GameLauncher
    {
        
    }
}