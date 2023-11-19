using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    internal static class BulletUtils
    {
        internal static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out Unit unit))
            {
                return;
            }

            if (bullet.IsPlayer == unit.teamComponent.IsPlayer)
            {
                return;
            }
            
            unit.hitPointsComponent.TakeDamage(bullet.Damage);
        }
    }
}