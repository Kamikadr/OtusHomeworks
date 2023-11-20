using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces;
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
        private Character _character;
        private IGameManager _gameManager;
        public void Initialize(IGameManager gameManager, Character character)
        {
            _gameManager = gameManager;
            _character = character;
        }
        private void OnEnable()
        {
            _character.hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject obj)
        {
            _gameManager.FinishGame();
        }

        private void OnDisable()
        {
            _character.hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void Start()
        {
            _character.hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        public void Finish()
        {
            _character.hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void Pause()
        {
            _character.hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }

        public void Resume()
        {
            _character.hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }
    }
}