using System;
using ShootEmUp.Bullets;
using ShootEmUp.GameInput;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterActionController: MonoBehaviour
    {
        private IMoveInput _moveInput;
        private IFireInput _fireInput;
        private Character _character;
        private IBulletSystem _bulletSystem;
        private CharacterBulletArgsFactory _bulletArgsFactory;
        
        public void Initialize(IBulletSystem bulletSystem, 
            IMoveInput moveInput, 
            IFireInput fireInput, 
            Character character, 
            CharacterBulletArgsFactory bulletArgsFactory)
        {
            _bulletSystem = bulletSystem;
            _moveInput = moveInput;
            _fireInput = fireInput;
            _character = character;
            _bulletArgsFactory = bulletArgsFactory;
        }
        public void Start()
        {
            _moveInput.OnMoveEvent += MoveCharacter;
            _fireInput.OnFireEvent += Fire;
        }
        private void Fire()
        {
            var bulletArgs = _bulletArgsFactory.Create();
            _bulletSystem.FlyBulletByArgs(bulletArgs);
        }
        private void MoveCharacter(MoveDirection direction)
        {
            _character.moveComponent.MoveByRigidbodyVelocity(direction.ConvertToVector2() * Time.fixedDeltaTime);
        }
        
        public void Finish()
        {
            _moveInput.OnMoveEvent -= MoveCharacter;
            _fireInput.OnFireEvent -= Fire;
        }
    }
}