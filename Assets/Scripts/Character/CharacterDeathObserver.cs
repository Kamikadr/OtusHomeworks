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

        public void Finish()
        {
            hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void Pause()
        {
            hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void Resume()
        {
            hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }
    }
}