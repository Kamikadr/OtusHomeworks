using Client.Components;
using Client.Components.Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client.Services
{
    public class DeathRequestSystem: IEcsRunSystem
    {
        private EcsFilterInject<Inc<DeathRequest>, Exc<Inactive>> _filter;
        private EcsPoolInject<DeathEvent> _deathEventsPool;
        private EcsPoolInject<Inactive> _inactivePool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                _deathEventsPool.Value.Add(entity) = new DeathEvent();
                _inactivePool.Value.Add(entity) = new Inactive();
                _filter.Pools.Inc1.Del(entity);
            }
        }
    }
}