using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyActionController: MonoBehaviour
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        
        private bool _isActive;
        private bool _isEnemyCanAttack;
        public void OnStart()
        {
            if (_isActive)
            {
                return;
            }
            
            enemyMoveAgent.IsReachedChange += OnReachedChange;
            enemyAttackController.SetActive(_isEnemyCanAttack);
            _isActive = true;
        }
        
        private void OnReachedChange(bool value)
        {
            enemyAttackController.SetActive(value);
            _isEnemyCanAttack = value;
        }

        public void OnStop()
        {
            if (!_isActive)
            {
                return;
            }
            enemyMoveAgent.IsReachedChange -= OnReachedChange;
            enemyAttackController.SetActive(false);
            _isActive = false;
        }

        public void Refresh()
        {
            _isEnemyCanAttack = false;
        }
    }
}