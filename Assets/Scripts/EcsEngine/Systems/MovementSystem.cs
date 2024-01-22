using Client.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client.Services
{
    public class MovementSystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection, MoveSpeed, Position>, Exc<Inactive>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var position = ref _filter.Pools.Inc3.Get(entity);
                var moveDirection = _filter.Pools.Inc1.Get(entity); 
                var moveSpeed = _filter.Pools.Inc2.Get(entity);

                position.value += moveDirection.value * (moveSpeed.value * Time.deltaTime);
            }
        }
    }
}