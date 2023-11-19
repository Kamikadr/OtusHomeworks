using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        public Vector2 Position => firePoint.position;
        public Quaternion Rotation => firePoint.rotation;
    }
}