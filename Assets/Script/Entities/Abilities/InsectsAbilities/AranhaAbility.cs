using UnityEngine;

namespace Entities.Abilities
{
    public class AranhaAbility : AbilityBase
    {
        public int debuffDamage = 1;
        public override void Cast()
        {
            int randomInt = Random.Range(0, EnemiesManager.Instance.queueAnimation.activeEnemies.Count - 1);
            EnemiesManager.Instance.queueAnimation.activeEnemies[randomInt].GetComponent<Entity>().Damage -= debuffDamage;
        }
    }
}
