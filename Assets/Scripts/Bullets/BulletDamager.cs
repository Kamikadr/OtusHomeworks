using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    internal class BulletDamager
    {
        public void DealDamage(Bullet bullet, GameObject other)
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