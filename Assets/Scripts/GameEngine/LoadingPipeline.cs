using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    [CreateAssetMenu(menuName = "Loading Tasks/LoadPipeline", fileName = "LoadPipeline")]
    public class LoadingPipeline: ScriptableObject
    {
        [SerializeField] private LoadingTask[] loadingTasks;

        public IEnumerable<LoadingTask> GetTasks()
        {
            return loadingTasks;
        }
    }
}