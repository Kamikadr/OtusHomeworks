using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int hitPoints;
        private int _hitPoint;
        
        public event Action<GameObject> HpIsEmptyEvent;
        public bool IsHitPointsExists() {
            return _hitPoint > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoint -= damage;
            if (_hitPoint <= 0)
            {
                HpIsEmptyEvent?.Invoke(gameObject);
            }
        }
        public void Refresh()
        {
            _hitPoint = hitPoints;
        }
    }
}