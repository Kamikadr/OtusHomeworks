using ShootEmUp.Bullets;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public sealed class EnemyAttackAgent
    {
        private readonly FireSetup _fireSetup;
        private readonly BulletConfig _bulletConfig;
        private readonly BulletSystem _bulletSystem;
        
        public EnemyAttackAgent(BulletSystem bulletSystem, FireSetup fireSetup, BulletConfig bulletConfig)
        {
            _bulletSystem = bulletSystem;
            _fireSetup = fireSetup;
            _bulletConfig = bulletConfig;
        }
        
        public void SetTarget(GameObject target)
        {
            _fireSetup.SetTarget(target);
        }
        public void Fire()
        {
            if (_fireSetup.TryGetFireData(out var fireData))
            {
               var bulletArgs = new BulletArgs
                {
                    IsPlayer = false,
                    PhysicsLayer = (int)_bulletConfig.physicsLayer,
                    Color = _bulletConfig.color,
                    Damage = _bulletConfig.damage,
                    Position = fireData.Position,
                    Velocity = fireData.Direction * 2.0f
                };
               _bulletSystem.FlyBulletByArgs(bulletArgs);
            }
        }
    }
}