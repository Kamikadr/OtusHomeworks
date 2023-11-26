using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyActionController: MonoBehaviour
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        
        private void OnEnable()
        {
            enemyMoveAgent.IsReachedChange += OnReachedChange;
        }
        
        private void OnReachedChange(bool value)
        {
            enemyAttackController.SetActive(value);
        }

        private void OnDisable()
        {
            enemyMoveAgent.IsReachedChange -= OnReachedChange;
        }
    }
}