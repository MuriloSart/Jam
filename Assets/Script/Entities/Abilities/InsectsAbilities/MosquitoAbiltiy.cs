using UnityEngine;

namespace Entities.Abilities
{
    public class MosquitoAbiltiy : AbilityBase
    {
        public int bonusDamage = 1;
        public int heal = 1;
        public override void Cast()
        {
            int randomInt = Random.Range(0, AlliesManager.Instance.alliesQueue.Count - 2);
            AlliesManager.Instance.alliesQueue[randomInt].Damage += bonusDamage;
            AlliesManager.Instance.alliesQueue[randomInt].health.Heal(heal);
        }
    }
}