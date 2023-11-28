using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class Character: MonoBehaviour, IGameStartListener
    {
        [SerializeField] public MoveComponent moveComponent;
        [SerializeField] public HitPointsComponent hitPointsComponent;
        [SerializeField] public WeaponComponent weaponComponent;
        [SerializeField] public TeamComponent teamComponent;
        public void OnStart()
        {
            hitPointsComponent.Refresh();
        }
    }
}