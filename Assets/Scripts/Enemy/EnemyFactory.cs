using ShootEmUp.Characters;
using ShootEmUp.Common;

namespace ShootEmUp.Enemies
{
    public class EnemyFactory : Factory<Enemy>
    {
        private readonly ICharacter _character;
        private readonly IEnemyPositionGetter _enemyPositions;

        public EnemyFactory(Enemy prefabItem, ICharacter character, IEnemyPositionGetter enemyPositions) : base(prefabItem)
        {
            _character = character;
            _enemyPositions = enemyPositions;
        }

        protected override void OnCreate(Enemy item)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            item.SetPosition(spawnPosition.position);
            var attackPosition = _enemyPositions.RandomAttackPosition();
            item.enemyMoveAgent.SetDestination(attackPosition.position);
            item.enemyAttackAgent.SetTarget(_character.GameObject);
        }
    }
}