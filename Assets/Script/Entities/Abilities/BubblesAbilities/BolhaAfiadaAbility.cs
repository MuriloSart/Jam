using UnityEngine;

namespace Entities.Abilities
{
    public class BolhaAfiadaAbilityB : AbilityBase
    {
        public int heal = 1;
        public int bonusDamage = 2;
        [SerializeField] private Entity entity;

        private void Start()
        {
            entity ??= GetComponent<Entity>();
        }

        public override void Cast()
        {
            entity.health.Heal(heal);
            entity.Damage += bonusDamage;
        }
    }
}
