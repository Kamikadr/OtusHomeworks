using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Common
{
    public class Timer: IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isCounting;
        
        
        public Action OnTimerIsOver;
        public Action<float> LastTimeEvent;
        
        public async Task StartCountdownAsync(TimerSettings timerSettings)
        {
            if (_isCounting)
            {
                return;
            }
            
            _cancellationTokenSource = new CancellationTokenSource();
            _isCounting = true;
            try
            {
                await CountdownTask(timerSettings.cooldownTime, timerSettings.cooldownTick, _cancellationTokenSource.Token);
                OnTimerIsOver?.Invoke();
            }
            finally
            {
                _isCounting = false;
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            
        }
        private async Task CountdownTask(float countdown, float tick, CancellationToken token = default)
        {
            var timeLeft = countdown;
            while (timeLeft > tick)
            {
                LastTimeEvent?.Invoke(timeLeft);
                await Task.Delay(TimeSpan.FromSeconds(tick), token);
                timeLeft -= tick;
            }
            LastTimeEvent?.Invoke(timeLeft);
            await Task.Delay(TimeSpan.FromSeconds(timeLeft), token);
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}