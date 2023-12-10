using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace App
{
    public class StartButtonListener: MonoBehaviour, IGameFinishListener
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        
        private GameCooldownLauncher _gameCooldownLauncher;

        [Inject]
        private void Construct(GameCooldownLauncher gameCooldownLauncher)
        {
            _gameCooldownLauncher = gameCooldownLauncher;
        }
        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            pauseButton.gameObject.SetActive(false);
        }

        private void StartGame()
        {
            _gameCooldownLauncher.StartGame();
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