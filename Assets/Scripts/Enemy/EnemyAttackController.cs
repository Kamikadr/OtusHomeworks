using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyAttackController: MonoBehaviour
    {
        [SerializeField] private EnemyAttacker enemyAttacker;
        [SerializeField] private CooldownCounter cooldownCounter;

        private void Awake()
        {
            cooldownCounter.CountIsDownEvent += Fire;
        }
        public void SetActive(bool value)
        {
            cooldownCounter.SetActive(value);
        }
        private void Fire()
        {
            enemyAttacker.Fire();
        }
        private void OnDestroy()
        {
            cooldownCounter.CountIsDownEvent -= Fire;
        }
        
    }
}