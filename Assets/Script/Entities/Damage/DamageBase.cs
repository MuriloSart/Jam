using Entities.Interfaces;
using UnityEngine;

namespace Entities.Damage
{
    public class DamageBase : MonoBehaviour, IDamageble
    {
        protected Entity entity;

        public void Initializer(Entity entity)
        {
            this.entity = entity;
        }

        public virtual void Deal(int damage, Entity entity)
        {
            var damageResult = damage - entity.health.CurrentArmor;

            if (damageResult < 0) return;

            entity.health.Damage(damageResult);
        }
    }
}