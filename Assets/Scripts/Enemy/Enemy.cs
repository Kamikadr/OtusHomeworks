using ShootEmUp.Common;
using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class Enemy: MonoBehaviour, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] public EnemyAttacker enemyAttacker;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        [SerializeField] public HitPointsComponent hitPointsComponent;
        private bool _isEnemyCanAttack;

        private void Awake()
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
            _isEnemyCanAttack = value;
            enemyAttackController.SetActive(value);
        }
        
        

        public void Finish()
        {
            enemyAttackController.SetActive(false);
            enemyMoveAgent.IsReachedChange -= OnReachedChange;
        }

        public void Pause()
        {
            enemyAttackController.SetActive(false);
        }

        public void Resume()
        {
            enemyAttackController.SetActive(_isEnemyCanAttack);
        }
    }
}