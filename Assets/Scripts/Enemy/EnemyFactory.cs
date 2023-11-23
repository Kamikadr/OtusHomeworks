using ShootEmUp.Bullets;
using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Game;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public class EnemyFactory : Factory<Enemy>
    {
        [SerializeField] private GameManager gameManager;
        protected override void OnCreate(Enemy item)
        {
            gameManager.AddListeners(item.gameObject);
            base.OnCreate(item);
        }
    }
}