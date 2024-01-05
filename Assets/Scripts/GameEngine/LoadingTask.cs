using System;
using Cysharp.Threading.Tasks;
using ModestTree.Util;
using UnityEngine;

namespace GameEngine
{
    public abstract class LoadingTask: ScriptableObject
    {
        public abstract void Do(Action<Result> callback);
        
        public class Result
        {
            public bool success;
            public string error;
            
            public static Result Success()
            {
                return new Result { success = true, error = null };
            }
        }

        
    }
}