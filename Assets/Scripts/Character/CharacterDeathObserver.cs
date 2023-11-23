using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterDeathObserver: MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private GameManager gameManager;
       
        private void OnEnable()
        {
            character.hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject obj)
        {
            gameManager.FinishGame();
        }

        private void OnDisable()
        {
            character.hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }
    }
}