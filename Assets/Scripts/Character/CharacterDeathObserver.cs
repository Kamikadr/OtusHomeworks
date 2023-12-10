using System;
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
        public event Action OnPlayerDeath;
        public CharacterDeathObserver(Character character)
        {
            _hitPointsComponent = character.hitPointsComponent;
        }

        private void OnCharacterDeath(GameObject obj)
        {
            OnPlayerDeath?.Invoke();
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