using System;
using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using ShootEmUp.GameInput;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterMoveController: IGameStartListener, IGameFinishListener
    {
        private readonly IMoveInput _moveInput;
        private readonly MoveComponent _moveComponent;
        
        public CharacterMoveController(IMoveInput moveInput, Character character)
        {
            _moveInput = moveInput;
            _moveComponent = character.moveComponent;
        }

        private void MoveCharacter(Vector2 destination)
        {
            _moveComponent.Move(destination);
        }

        public void OnStart()
        {
            _moveInput.OnMoveEvent += MoveCharacter;
        }

        public void OnFinish()
        {
            _moveInput.OnMoveEvent -= MoveCharacter;
        }
    }
}