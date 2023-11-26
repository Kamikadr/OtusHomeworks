using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class EnemyAttackController: MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
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
            enemyAttackAgent.Fire();
        }
        private void OnDestroy()
        {
            cooldownCounter.CountIsDownEvent -= Fire;
        }
        
    }
}