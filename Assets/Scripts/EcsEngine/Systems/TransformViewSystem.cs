using Client.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client.Services
{
    public class TransformViewSystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<Position, TransformView>> _filter;
        private EcsPoolInject<Position> _positionPool;
        private EcsPoolInject<TransformView> _transformPool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var transform = ref _filter.Pools.Inc2.Get(entity);
                var position = _filter.Pools.Inc1.Get(entity);

                transform.value.position = position.value;
            }
        }
    }
}