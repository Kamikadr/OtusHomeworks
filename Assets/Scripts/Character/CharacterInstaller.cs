using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class CharacterInstaller: MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterDeathObserver characterDeathObserver;
        [SerializeField] private CharacterActionController characterActionController;
        [SerializeField] private KeyboardInput keyboardInput;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletConfig bulletConfig;


        private void Awake()
        {
            characterDeathObserver.Initialize(gameManager, character);

            var bulletArgsFactory = new CharacterBulletArgsFactory(character, bulletConfig);
            characterActionController.Initialize(bulletSystem,
                keyboardInput,keyboardInput,character, bulletArgsFactory);
        }
    }
}