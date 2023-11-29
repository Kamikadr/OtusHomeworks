using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseResumeButtonListener: MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        public void OnStart()
        {
            pauseButton.onClick.AddListener(OnPauseClickListener);
            resumeButton.onClick.AddListener(OnResumeClickListener);
        }

        private void OnResumeClickListener()
        {
            gameManager.ResumeGame();
        }

        private void OnPauseClickListener()
        {
            gameManager.PauseGame();
        }

        public void OnFinish()
        {
            pauseButton.onClick.RemoveListener(OnPauseClickListener);
            resumeButton.onClick.RemoveListener(OnResumeClickListener);
        }

    }
}