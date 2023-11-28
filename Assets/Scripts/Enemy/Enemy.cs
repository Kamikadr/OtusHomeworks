using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class Enemy: MonoBehaviour, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] private EnemyActionController enemyActionController;
        [SerializeField] public EnemyAttackAgent enemyAttackAgent;
        [SerializeField] public EnemyMoveAgent enemyMoveAgent;
        [SerializeField] public HitPointsComponent hitPointsComponent;


        public void Activate()
        {
            enemyActionController.OnStart();
            hitPointsComponent.Refresh();
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
            enemyActionController.OnStop();
        }
        public void Resume()
        {
            enemyActionController.OnStart();
        }
        public void Deactivate()
        {
            enemyActionController.OnStop();
            enemyActionController.Refresh();
        }
    }
}