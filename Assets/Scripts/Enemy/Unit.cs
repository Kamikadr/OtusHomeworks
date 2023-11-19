using UnityEngine;

namespace ShootEmUp
{
    public class Unit: MonoBehaviour
    {
        [SerializeField] public MoveComponent moveComponent;
        [SerializeField] public HitPointsComponent hitPointsComponent;
        [SerializeField] public WeaponComponent weaponComponent;
        [SerializeField] public TeamComponent teamComponent;
    }
}