using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace App
{
    public class StartButtonListener: MonoBehaviour, IGameFinishListener
    {
        [SerializeField] private GameCooldownLauncher gameCooldownLauncher;
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            pauseButton.gameObject.SetActive(false);
        }

        private void StartGame()
        {
            gameCooldownLauncher.StartGame();
            startButton.gameObject.SetActive(false);
            
            startButton.onClick.RemoveListener(StartGame);
        }

        public void OnFinish()
        {
            startButton.onClick.AddListener(StartGame);
            startButton.gameObject.SetActive(true);
        }
    }
}