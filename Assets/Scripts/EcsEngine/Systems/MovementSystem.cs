using Client.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client.Services
{
    public class MovementSystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection, MoveSpeed, Position>> _filter;
        private EcsPoolInject<MoveDirection> _moveDirectionPool;
        private EcsPoolInject<MoveSpeed> _moveSpeedPool;
        private EcsPoolInject<Position> _positionPool;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var position = ref _positionPool.Value.Get(entity);
                var moveDirection = _moveDirectionPool.Value.Get(entity); 
                var moveSpeed = _moveSpeedPool.Value.Get(entity);

                position.value += moveDirection.value * (moveSpeed.value * Time.deltaTime);
            }
        }
    }
}