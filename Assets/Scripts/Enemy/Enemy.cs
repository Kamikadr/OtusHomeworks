using ShootEmUp.Common;
using ShootEmUp.Componets;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class Enemy: MonoBehaviour
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] public EnemyAttacker enemyAttacker;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        [SerializeField] public HitPointsComponent hitPointsComponent;

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
            enemyAttackController.SetActive(value);
        }

        private void OnDisable()
        {
            enemyMoveAgent.IsReachedChange -= OnReachedChange;
        }
    }
}