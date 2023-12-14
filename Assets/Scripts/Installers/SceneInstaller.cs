using UnityEngine;
using Views;
using Zenject;

namespace Installers
{
    public class SceneInstaller: MonoInstaller
    {
        [SerializeField] private CharacterStatView characterStatViewPrefab;
        [SerializeField] private Transform poolContainer;
        public override void InstallBindings()
        {
            Container.BindInstances(characterStatViewPrefab);
            Container.Bind<ViewFactory<CharacterStatView>>().AsSingle();
            Container.Bind<ViewPool<CharacterStatView>>().AsSingle().WithArguments(poolContainer);
        }
    }
}