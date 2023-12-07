using ShootEmUp.Bullets;
using ShootEmUp.Game.Interfaces.GameCycle;
using ShootEmUp.GameInput;
using UnityEngine;
using VContainer;

namespace ShootEmUp.Characters
{
    public class CharacterFireController: IGameStartListener, IGameFinishListener
    {
        private readonly IFireInput _fireInput;
        private readonly BulletSystem _bulletSystem;
        private readonly Character _character;
        private readonly BulletConfig _bulletConfig;

        public CharacterFireController(BulletSystem bulletSystem, IFireInput fireInput, Character character, BulletConfig bulletConfig)
        {
            _bulletSystem = bulletSystem;
            _fireInput = fireInput;
            _character = character;
            _bulletConfig = bulletConfig;
        }
        public void OnStart()
        {
            _fireInput.OnFireEvent += Fire;
        }
        private void Fire()
        {
            var weapon = _character.weaponComponent;
            var bulletArgs = new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int) _bulletConfig.physicsLayer,
                Color = _bulletConfig.color,
                Damage = _bulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * _bulletConfig.speed
            };
            _bulletSystem.FlyBulletByArgs(bulletArgs);
        }
  
        
        public void OnFinish()
        {
            _fireInput.OnFireEvent -= Fire;
        }
    }
}