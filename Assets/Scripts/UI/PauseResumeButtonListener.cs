using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class PauseResumeButtonListener: MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void OnStart()
        {
            pauseButton.onClick.AddListener(OnPauseClickListener);
            resumeButton.onClick.AddListener(OnResumeClickListener);
        }

        private void OnResumeClickListener()
        {
            _gameManager.ResumeGame();
        }

        private void OnPauseClickListener()
        {
            _gameManager.PauseGame();
        }

        public void OnFinish()
        {
            pauseButton.onClick.RemoveListener(OnPauseClickListener);
            resumeButton.onClick.RemoveListener(OnResumeClickListener);
        }

    }
}