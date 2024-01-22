using Client.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client.Services
{
    public class TransformViewSystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<Position, TransformView>> _filter;
        private EcsPoolInject<Rotation> _rotationPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var transform = ref _filter.Pools.Inc2.Get(entity);
                var position = _filter.Pools.Inc1.Get(entity);

                transform.value.position = position.value;
                if (_rotationPool.Value.Has(entity))
                {
                    var rotation = _rotationPool.Value.Get(entity);
                    transform.value.rotation = rotation.value;
                }
            }
        }
    }
}