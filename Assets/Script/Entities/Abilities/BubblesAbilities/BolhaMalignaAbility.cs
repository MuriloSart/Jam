using UnityEngine;

namespace Entities.Abilities
{
    public class BolhaMalignaAbility : AbilityBase
    {
        public int abilityDamage = 2;

        public override void Cast()
        {
            int randomInt = Random.Range( 1, AlliesManager.Instance.queueAnimation.activeAllies.Count - 1);
            AlliesManager.Instance.queueAnimation.activeAllies[randomInt].GetComponent<Entity>().health.Damage(abilityDamage);
        }
    }
}
