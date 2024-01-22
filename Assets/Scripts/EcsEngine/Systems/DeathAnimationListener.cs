using Client.Components;
using Client.Components.Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client.Services
{
    public class DeathAnimationListener: IEcsRunSystem
    {
        private static readonly int Death = Animator.StringToHash("Death");
        private EcsFilterInject<Inc<AnimatorView, DeathEvent>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var animatorView = _filter.Pools.Inc1.Get(entity);
                animatorView.value.SetTrigger(Death);
            }
        }
    }
}