using System;
using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Game
{
    public class StartCountdownObserver: IDisposable
    {
        private readonly Timer _timer;

        public StartCountdownObserver(Timer timer)
        {
            _timer = timer;
            _timer.LastTimeEvent += DebugTimeInfo;
        }
        
        private void DebugTimeInfo(float lastTime)
        {
            Debug.Log($"The game will start in {lastTime} second");
        }
        

        public void Dispose()
        {
            _timer.LastTimeEvent -= DebugTimeInfo;
        }
    }
}