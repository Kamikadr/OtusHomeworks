using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game
{
    public class GameLifecycleMediator: MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private StartTimer startTimer;
        
        public void StartGame()
        {
            startTimer.OnTimerIsOver += RunGame;
            startTimer.StartCountdown();
        }
        

        public void Pause()
        {
            gameManager.PauseGame();
        }

        public void Resume()
        {
            gameManager.ResumeGame();
        }
        private void RunGame()
        {
            startTimer.OnTimerIsOver -= RunGame;
            gameManager.StartGame();
        }
        private void OnDestroy()
        {
            startTimer.OnTimerIsOver -= RunGame;
        }
    }
}