using System;
using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using ShootEmUp.GameInput;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class CharacterMoveController:MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private KeyboardInput input;
        [SerializeField] private MoveComponent moveComponent;
        
        private void MoveCharacter(Vector2 destination)
        {
            moveComponent.Move(destination);
        }

        public void OnStart()
        {
            input.OnMoveEvent += MoveCharacter;
        }

        public void Finish()
        {
            input.OnMoveEvent -= MoveCharacter;
        }
    }
}