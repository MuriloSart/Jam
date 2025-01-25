using UnityEngine;

namespace Entities.Abilities
{
    public class MosquitoAbiltiy : AbilityBase
    {
        public int bonusDamage = 1;
        public int heal = 1;
        public override void Cast()
        {
            int randomInt = Random.Range(0, AlliesManager.Instance.queueAnimation.activeAllies.Count - 2);
            AlliesManager.Instance.queueAnimation.activeAllies[randomInt].GetComponent<Entity>().Damage += bonusDamage;
            AlliesManager.Instance.queueAnimation.activeAllies[randomInt].GetComponent<Entity>().health.Heal(heal);
        }
    }
}