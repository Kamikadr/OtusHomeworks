using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game
{
    public class StartCountdownObserver: MonoBehaviour
    {
        [SerializeField] private StartTimer startTimer;

        private void Awake()
        {
            startTimer.LastTimeEvent += DebugTimeInfo;
        }

        private void DebugTimeInfo(float lastTime)
        {
            Debug.Log($"the game will start in {lastTime} second");
        }

        private void OnDestroy()
        {
            startTimer.LastTimeEvent -= DebugTimeInfo;
        }
    }
}