using UnityEngine;

namespace Entities.Abilities
{
    public class BolhaPoderosaAbility : AbilityBase
    {
        public int bonusDamage = 1;
        public int bonusHealth = 1;

        [SerializeField]private Entity entity;
        private void Start()
        {
            entity ??= GetComponent<Entity>();
        }

        public override void Cast()
        {
            entity.Damage += bonusDamage;
            entity.health.Heal(bonusHealth);
        }
    }

}
