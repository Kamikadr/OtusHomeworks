using System;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletInstaller: MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletPoolTransform;
        private void Awake()
        {
            var bulletFactory = new Factory<Bullet>(bulletPrefab);
            var bulletPool = new Pool<Bullet>(bulletFactory, bulletPoolTransform);
            bulletSystem.Initialize(bulletPool);
        }
    }
}