using Client.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client.Services
{
    public class HpEmptySystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<Health>, Exc<DeathRequest, DeadTag>> _filter;
        private EcsPoolInject<DeathRequest> _deathRequestPool;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var health = _filter.Pools.Inc1.Get(entity);
                if (health.value <= 0)
                {
                    _deathRequestPool.Value.Add(entity) = new DeathRequest();
                }
            }
        }
    }
}