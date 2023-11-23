using ShootEmUp.Componets;
using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterDeathObserver: MonoBehaviour
    {
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private GameManager gameManager;
       
        private void OnEnable()
        {
            hitPointsComponent.HpIsEmptyEvent += OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject obj)
        {
            gameManager.FinishGame();
        }

        private void OnDisable()
        {
            hitPointsComponent.HpIsEmptyEvent -= OnCharacterDeath;
        }
    }
}