using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Level
{
    public sealed class LevelBackground : IFixedUpdateListener
    {
        private readonly BackgroundMoveConfig _backgroundMoveConfig;
        private readonly Transform _backgroundTransform;
        private readonly float _startPositionY;
        private readonly float _endPositionY;
        private readonly float _movingSpeedY;
        private readonly float _positionX;
        private readonly float _positionZ;
        

        public LevelBackground(BackgroundMoveConfig backgroundMoveConfig, Transform backgroundTransform)
        {
            _backgroundMoveConfig = backgroundMoveConfig;
            _backgroundTransform = backgroundTransform;

            _startPositionY = _backgroundMoveConfig.startPositionY;
            _endPositionY = _backgroundMoveConfig.endPositionY;
            _movingSpeedY = _backgroundMoveConfig.movingSpeedY;
            var position = _backgroundTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_backgroundTransform.position.y <= _endPositionY)
            {
                _backgroundTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }
            else
            {
                _backgroundTransform.position -= new Vector3(
                    _positionX,
                    _movingSpeedY * deltaTime,
                    _positionZ
                );
            }
        }

        
    }
}