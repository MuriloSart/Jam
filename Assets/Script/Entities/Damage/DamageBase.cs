using Entities.Health;
using Entities.Interfaces;
using UnityEngine;

namespace Entities.Damage
{
    public class DamageBase : MonoBehaviour, IDamageble
    {
        public Entity entity;

        public virtual void Deal(int damage, HealthBase health)
        {
            var damageResult = damage - health.CurrentArmor;

            if (damageResult < 0)
            {
                Debug.Log("Dano insuficiente para superar a armadura.");
                return;
            }

            health.Damage(damageResult);
        }
    }
}