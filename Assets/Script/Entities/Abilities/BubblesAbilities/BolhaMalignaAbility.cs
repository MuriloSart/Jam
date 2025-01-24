using UnityEngine;

namespace Entities.Abilities
{
    public class BolhaMalignaAbility : AbilityBase
    {
        public int abilityDamage = 2;

        public override void Cast()
        {
            int randomInt = Random.Range(0, EnemiesManager.Instance.enemiesQueue.Count - 1);
            EnemiesManager.Instance.enemiesQueue[randomInt].health.Damage(abilityDamage);
        }
    }
}
