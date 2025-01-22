using UnityEngine;

namespace Entities.Abilities
{
    public class AranhaAbility : AbilityBase
    {
        public int debuffDamage = 1;
        public override void Cast()
        {
            int randomInt = Random.Range(0, EnemiesManager.Instance.enemies.Count - 1);
            EnemiesManager.Instance.enemies[randomInt].Damage -= debuffDamage;
        }
    }
}
