using ShootEmUp.Componets;
using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterDeathObserver: 
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        private readonly HitPointsComponent _hitPointsComponent;
        private readonly GameManager _gameManager;
        public CharacterDeathObserver(GameManager gameManager, HitPointsComponent hitPointsComponent)
        {
            _gameManager = gameManager;
            _hitPointsComponent = hitPointsComponent;
        }

        private void OnCharacterDeath(GameObject obj)
        {
            _gameManager.FinishGame();
        }
        
        public void OnStart()
        {
            _hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        public void OnFinish()
        {
            _hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void OnPause()
        {
            _hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void OnResume()
        {
            _hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }
    }
}