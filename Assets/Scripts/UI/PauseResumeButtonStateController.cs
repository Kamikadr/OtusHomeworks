using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseResumeButtonStateController: MonoBehaviour,
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;


        public void OnStart()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnFinish()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnPause()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
        }

        public void OnResume()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }
    }
}