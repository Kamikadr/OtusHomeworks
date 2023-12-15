using App;
using Game;
using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Componets;
using ShootEmUp.Enemies;
using ShootEmUp.Game;
using ShootEmUp.GameInput;
using ShootEmUp.Level;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Bullets
{
    public class SceneLifetimeScope: LifetimeScope
    {
        [SerializeField] private Installer[] installers;
        protected override void Configure(IContainerBuilder builder)
        {
            for (int i = 0; i < installers.Length; i++)
            {
                installers[i].Configure(builder);
            }
        }
    }
}