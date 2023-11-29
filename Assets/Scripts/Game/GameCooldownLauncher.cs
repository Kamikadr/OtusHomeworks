using System;
using ShootEmUp.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game
{
    public class GameCooldownLauncher: MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [FormerlySerializedAs("startTimer")] [SerializeField] private Timer timer;
        
        public void StartGame()
        {
            timer.OnTimerIsOver += RunGame;
            timer.StartCountdown();
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
            timer.OnTimerIsOver -= RunGame;
            gameManager.StartGame();
        }
        private void OnDestroy()
        {
            timer.OnTimerIsOver -= RunGame;
        }
    }
}