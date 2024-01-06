using System.Collections.Generic;
using GameEngine;
using UnityEngine;

namespace App
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