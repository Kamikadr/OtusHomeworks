using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterDeathObserver: MonoBehaviour
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
    }
}