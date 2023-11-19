using ShootEmUp.Bullets;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyBulletArgsFactory
    {
        private readonly BulletConfig _bulletConfig;

        public EnemyBulletArgsFactory(BulletConfig bulletConfig)
        {
            _bulletConfig = bulletConfig;
        }

        public BulletArgs Create(Vector2 position, Vector2 direction)
        {
            return new BulletArgs
            {
                IsPlayer = false,
                PhysicsLayer = (int)_bulletConfig.physicsLayer,
                Color = _bulletConfig.color,
                Damage = _bulletConfig.damage,
                Position = position,
                Velocity = direction * 2.0f
            };
        }
    }
}