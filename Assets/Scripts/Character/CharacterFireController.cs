using ShootEmUp.Bullets;
using ShootEmUp.Game.Interfaces.GameCycle;
using ShootEmUp.GameInput;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterFireController: MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private KeyboardInput fireInput;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Character character;
        [SerializeField] private BulletConfig bulletConfig;
        
        
        public void OnStart()
        {
            fireInput.OnFireEvent += Fire;
        }
        private void Fire()
        {
            var weapon = character.weaponComponent;
            var bulletArgs = new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int) bulletConfig.physicsLayer,
                Color = bulletConfig.color,
                Damage = bulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
            };
            bulletSystem.FlyBulletByArgs(bulletArgs);
        }
  
        
        public void Finish()
        {
            fireInput.OnFireEvent -= Fire;
        }
    }
}