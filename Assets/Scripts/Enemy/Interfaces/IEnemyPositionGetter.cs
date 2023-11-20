using UnityEngine;

namespace ShootEmUp.Enemies
{
    public interface IEnemyPositionGetter
    {
        Transform RandomSpawnPosition();
        Transform RandomAttackPosition();
    }
}