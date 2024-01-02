using Cysharp.Threading.Tasks;
using GameEngine;
using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(menuName = "Loading Tasks/SaveLoadTask", fileName = "Save Load Task")]
    public class LoadTask: LoadingTask
    {
        public override UniTask<Result> Do()
        {
            throw new System.NotImplementedException();
        }
    }
}