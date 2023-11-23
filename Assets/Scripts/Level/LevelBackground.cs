using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Level
{
    public sealed class LevelBackground : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private BackgroundMoveConfig backgroundMoveConfig;
        
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;
        
        private void Awake()
        {
            _startPositionY = backgroundMoveConfig.startPositionY;
            _endPositionY = backgroundMoveConfig.endPositionY;
            _movingSpeedY = backgroundMoveConfig.movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnFixedUpdate()
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        
    }
}