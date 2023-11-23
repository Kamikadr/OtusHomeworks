using ShootEmUp.Common;
using ShootEmUp.Componets;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    internal static class BulletDamager
    {
        public static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                return;
            }
            if (!other.TryGetComponent(out TeamComponent teamComponent))
            {
                return;
            }
            if (bullet.IsPlayer == teamComponent.IsPlayer)
            {
                return;
            }
            
            hitPoints.TakeDamage(bullet.Damage);
        }
    }
}