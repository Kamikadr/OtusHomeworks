using System;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private BulletArgs _bulletData;
        
        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }
        public void SetBulletArgs(BulletArgs bulletData)
        {
            _bulletData = bulletData;
            
            rigidbody2D.velocity = _bulletData.Velocity;
            gameObject.layer = _bulletData.PhysicsLayer;
            transform.position = _bulletData.Position;
            spriteRenderer.color = _bulletData.Color;
            Damage = _bulletData.Damage;
            IsPlayer = _bulletData.IsPlayer;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}