using ShootEmUp.Componets;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class Enemy: MonoBehaviour
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] public EnemyAttackAgent enemyAttackAgent;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        [SerializeField] public HitPointsComponent hitPointsComponent;
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

    }
}