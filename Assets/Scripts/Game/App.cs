using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace App
{
    public class App: MonoBehaviour, IGameFinishListener
    {
        [SerializeField, ReadOnly] private GameState gameState;
        [SerializeField] private GameLifecycleMediator gameLifecycleMediator;
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            pauseButton.onClick.AddListener(Pause);
            pauseButton.gameObject.SetActive(false);
        }

        private void StartGame()
        {
            gameLifecycleMediator.StartGame();
            startButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            gameState = GameState.Playing;

        }

        public void Finish()
        {
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            gameState = GameState.Finished;
        }

        private void Pause()
        {
            if (gameState == GameState.Playing)
            {
                gameLifecycleMediator.Pause();
                gameState = GameState.Paused;
            }
            else
            {
                gameLifecycleMediator.Resume();
                gameState = GameState.Playing;
            }
        }
    }

    internal enum GameState
    {
        None,
        Playing,
        Paused,
        Finished
    }
}