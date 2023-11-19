using System;
using ShootEmUp;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private CooldownCounter cooldownCounter;
        [SerializeField] private Attacker attacker;
        
        public event Action<GameObject, Vector2, Vector2> OnFire;
        
        private void OnEnable()
        {
            cooldownCounter.CountIsDownEvent += Fire;
        }
        public void SetActive(bool value)
        {
            cooldownCounter.SetActive(value);
        }
        public void SetTarget(GameObject target)
        {
            attacker.SetTarget(target);
        }
        private void Fire()
        {
            if (attacker.TryGetFireData(out var fireData))
            {
                OnFire?.Invoke(fireData.sender, fireData.position, fireData.direction);
            }
        }

        private void OnDisable()
        {
            cooldownCounter.CountIsDownEvent -= Fire;
        }
    }
}