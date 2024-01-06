using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class AppLoader: MonoBehaviour
    {
        [SerializeField] private LoadingPipeline loadingPipeline;

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        private async void Start()
        {
            var tasks = loadingPipeline.GetTasks();
            foreach (var task in tasks)
            {
                _container.Inject(task);
                var result = await DoTask(task);
                if (!result.success)
                {
                    throw new Exception("Task Error");
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