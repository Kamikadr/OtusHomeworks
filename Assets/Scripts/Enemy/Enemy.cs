using System;
using ShootEmUp.Componets;
using UnityEngine;
using VContainer;

namespace ShootEmUp.Enemies
{
    
    public class Enemy: MonoBehaviour
    {
        private EnemyAttackController _enemyAttackController;
        private EnemyActionController _enemyActionController;
        private EnemyAttackAgent _enemyAttackAgent;
        private EnemyMoveAgent _enemyMoveAgent;
        private HitPointsComponent _hitPointsComponent;
        public event Action<Enemy> OnEnemyKilled;

        [Inject]
        public void Construct(EnemyAttackController enemyAttackController,
            EnemyAttackAgent enemyAttackAgent,
            EnemyMoveAgent enemyMoveAgent,
            HitPointsComponent hitPointsComponent
            )
        {
            _enemyAttackController = enemyAttackController;
            _enemyAttackAgent = enemyAttackAgent;
            _enemyMoveAgent = enemyMoveAgent;
            _hitPointsComponent = hitPointsComponent;
            _enemyActionController = new EnemyActionController(_enemyMoveAgent, _enemyAttackController);
        }
        public void Activate()
        {
            _enemyActionController.OnStart();
            _hitPointsComponent.Refresh();
            _hitPointsComponent.HpIsEmptyEvent += OnHpIsEmptyEvent;
        }

        private void OnHpIsEmptyEvent(GameObject _)
        {
            OnEnemyKilled?.Invoke(this);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }
        
        public void Pause()
        {
            _enemyActionController.OnStop();
        }
        public void Resume()
        {
            _enemyActionController.OnStart();
        }
        public void Deactivate()
        {
            _enemyActionController.OnStop();
            _enemyActionController.Refresh();
        }


        public void SetTarget(GameObject target)
        {
            _enemyAttackAgent.SetTarget(target);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _enemyMoveAgent.SetDestination(endPoint);
        }
        
    }
}