using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyActionController
    {
        private readonly EnemyAttackController _enemyAttackController;
        private readonly EnemyMoveAgent _enemyMoveAgent;
        
        private bool _isActive;
        private bool _isEnemyCanAttack;

        public EnemyActionController(EnemyMoveAgent enemyMoveAgent, EnemyAttackController enemyAttackController)
        {
            _enemyMoveAgent = enemyMoveAgent;
            _enemyAttackController = enemyAttackController;
        }

        public void OnStart()
        {
            if (_isActive)
            {
                return;
            }
            
            _enemyMoveAgent.IsReachedChange += OnReachedChange;
            _enemyAttackController.SetActive(_isEnemyCanAttack);
            _isActive = true;
        }
        
        private void OnReachedChange(bool value)
        {
            _enemyAttackController.SetActive(value);
            _isEnemyCanAttack = value;
        }

        public void OnStop()
        {
            if (!_isActive)
            {
                return;
            }
            _enemyMoveAgent.IsReachedChange -= OnReachedChange;
            _enemyAttackController.SetActive(false);
            _isActive = false;
        }

        public void Refresh()
        {
            _isEnemyCanAttack = false;
        }
    }
}