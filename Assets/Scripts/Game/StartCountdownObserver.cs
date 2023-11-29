using System;
using ShootEmUp.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game
{
    public class StartCountdownObserver: MonoBehaviour
    {
        [FormerlySerializedAs("startTimer")] [SerializeField] private Timer timer;

        private void Awake()
        {
            timer.LastTimeEvent += DebugTimeInfo;
        }

        private void DebugTimeInfo(float lastTime)
        {
            Debug.Log($"the game will start in {lastTime} second");
        }

        private void OnDestroy()
        {
            timer.LastTimeEvent -= DebugTimeInfo;
        }
    }
}