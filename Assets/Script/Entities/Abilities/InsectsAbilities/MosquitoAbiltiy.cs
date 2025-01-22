using UnityEngine;

namespace Entities.Abilities
{
    public class MosquitoAbiltiy : AbilityBase
    {
        public int bonusDamage = 1;
        public int heal = 1;
        public override void Cast()
        {
            int randomInt = Random.Range(0, AlliesManager.Instance.allies.Count - 2);
            AlliesManager.Instance.allies[randomInt].Damage += bonusDamage;
            AlliesManager.Instance.allies[randomInt].health.Heal(heal);
        }
    }
}