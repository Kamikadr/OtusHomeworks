using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class Enemy: Unit
    {
        [SerializeField] public EnemyAttackAgent enemyAttackAgent;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        
        private void OnEnable()
        {
            enemyMoveAgent.IsReachedChange += OnReachedChange;
        }
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

        private void OnReachedChange(bool value)
        {
            enemyAttackAgent.SetActive(value);
        }

        private void OnDisable()
        {
            enemyMoveAgent.IsReachedChange -= OnReachedChange;
        }
    }
}