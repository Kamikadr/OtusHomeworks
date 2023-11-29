using ShootEmUp.Componets;
using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterDeathObserver: MonoBehaviour,
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private GameManager gameManager;
        

        private void OnCharacterDeath(GameObject obj)
        {
            gameManager.FinishGame();
        }
        
        public void OnStart()
        {
            hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        public void OnFinish()
        {
            hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void OnPause()
        {
            hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void OnResume()
        {
            hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }
    }
}