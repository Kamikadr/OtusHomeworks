using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App.LoadingTasks
{
    public sealed class GameLauncher
    {
        private const string LaunchPipelineKey = "GameLaunchPipeline";

        public async UniTask LaunchGame(DiContainer container)
        {
            var pipeline = Resources.Load<LoadingPipeline>(LaunchPipelineKey);
            var tasks = pipeline.GetTasks();

            foreach (var task in tasks)
            {
                container.Inject(task);
                var result = await DoTask(task);
                if (!result.success)
                {
                    throw new Exception("Game Task Error");
                }
            }
        }
        
        private UniTask<LoadingTask.Result> DoTask(LoadingTask task)
        {
            var tcs = new UniTaskCompletionSource<LoadingTask.Result>();
            task.Do(result => tcs.TrySetResult(result));
            return tcs.Task;
        }
    }
}