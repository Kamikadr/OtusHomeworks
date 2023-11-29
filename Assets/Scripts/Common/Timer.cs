using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Common
{
    public class Timer: MonoBehaviour
    {
        [SerializeField] private float countdown;
        [SerializeField] private float tick;
        public Action OnTimerIsOver;
        public Action<float> LastTimeEvent;
        public void StartCountdown()
        {
            StartCoroutine(CountdownCoroutine());
        }
        private IEnumerator CountdownCoroutine()
        {
            var timeLeft = countdown;
            while (timeLeft > 0)
            {
                LastTimeEvent?.Invoke(timeLeft);
                yield return new WaitForSecondsRealtime(tick);
                timeLeft -= tick;
            }
            OnTimerIsOver?.Invoke();
        }

    }
}