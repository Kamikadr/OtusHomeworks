using System;
using ShootEmUp.Componets;
using ShootEmUp.GameInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Characters
{
    public class CharacterMoveController:MonoBehaviour
    {
        [SerializeField] private KeyboardInput input;
        [SerializeField] private MoveComponent moveComponent;


        private void OnEnable()
        {
            input.OnMoveEvent += MoveCharacter;
        }

        private void MoveCharacter(Vector2 destination)
        {
            moveComponent.Move(destination);
        }

        private void OnDisable()
        {
            input.OnMoveEvent -= MoveCharacter;
        }
    }
}