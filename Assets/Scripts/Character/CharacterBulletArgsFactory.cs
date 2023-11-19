using ShootEmUp.Bullets;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterBulletArgsFactory: BulletArgsFactory
    {
        private readonly Character _character;

        public CharacterBulletArgsFactory(Character character, BulletConfig bulletConfig): base(bulletConfig)
        {
            _character = character;
        }
        public override BulletArgs Create()
        {
            var weapon = _character.weaponComponent;
            return new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int) BulletConfig.physicsLayer,
                Color = BulletConfig.color,
                Damage = BulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * BulletConfig.speed
            };
        }
    }

    public abstract class BulletArgsFactory
    {
        protected readonly BulletConfig BulletConfig;

        protected BulletArgsFactory(BulletConfig bulletConfig)
        {
            BulletConfig = bulletConfig;
        }
        public abstract BulletArgs Create();
    }
}