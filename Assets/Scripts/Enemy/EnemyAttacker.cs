using ShootEmUp.Bullets;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public sealed class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private FireSetup fireSetup;
        [SerializeField] private BulletConfig bulletConfig;
        private BulletSystem _bulletSystem;
        
        public void SetTarget(GameObject target)
        {
            fireSetup.SetTarget(target);
        }

        public void Construct(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }
        public void Fire()
        {
            if (fireSetup.TryGetFireData(out var fireData))
            {
               var bulletArgs = new BulletArgs
                {
                    IsPlayer = false,
                    PhysicsLayer = (int)bulletConfig.physicsLayer,
                    Color = bulletConfig.color,
                    Damage = bulletConfig.damage,
                    Position = fireData.Position,
                    Velocity = fireData.Direction * 2.0f
                };
               _bulletSystem.FlyBulletByArgs(bulletArgs);
            }
        }
    }
}