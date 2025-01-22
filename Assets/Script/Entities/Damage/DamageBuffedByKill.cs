using UnityEngine;

namespace Entities.Damage
{
    public class DamageBuffedByKill : DamageBase
    {
        [SerializeField] private Entity entity;

        private void Start()
        {
            entity ??= GetComponent<Entity>();
        }
        public override int Deal(int damage, int amoor, int currentHealth)
        {
            var damageResult = damage - amoor;

            if (damageResult < 0) return currentHealth;

            var result = currentHealth - damageResult;

            if (result <= 0) entity.UseAbility(); 

            return result;
        }
    }
}