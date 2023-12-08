using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class EnemyAttackController: IDisposable
    {
        private readonly EnemyAttackAgent _enemyAttackAgent;
        private readonly CooldownCounter _cooldownCounter;

        public EnemyAttackController(EnemyAttackAgent enemyAttackAgent, CooldownCounter cooldownCounter)
        {
            _enemyAttackAgent = enemyAttackAgent;
            _cooldownCounter = cooldownCounter;
        }
        public void SetActive(bool value)
        {
            if (value)
            {
                _cooldownCounter.CountIsDownEvent += Fire;
            }
            else
            {
                _cooldownCounter.CountIsDownEvent -= Fire;
            }
            
            _cooldownCounter.SetActive(value);
        }
        private void Fire()
        {
            _enemyAttackAgent.Fire();
        }
        public void Dispose()
        {
            _cooldownCounter.CountIsDownEvent -= Fire;
        }
        
    }
}