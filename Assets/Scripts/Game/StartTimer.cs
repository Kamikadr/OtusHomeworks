using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Game
{
    public class StartTimer: MonoBehaviour
    {
        [SerializeField] private float countdown;
        [SerializeField] private float tick;
        public Action OnTimerIsOver;
        public Action<float> LastTimeEvent;
        public void StartCountdown()
        {
            StartCoroutine(CountdownCorutine());
        }
        private IEnumerator CountdownCorutine()
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