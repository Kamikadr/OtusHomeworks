using ShootEmUp.Componets;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class Character: MonoBehaviour
    {
        [SerializeField] public MoveComponent moveComponent;
        [SerializeField] public HitPointsComponent hitPointsComponent;
        [SerializeField] public WeaponComponent weaponComponent;
        [SerializeField] public TeamComponent teamComponent;
    }
}