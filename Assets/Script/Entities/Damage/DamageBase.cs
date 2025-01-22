using Entities.Interfaces;
using UnityEngine;

namespace Entities.Damage
{
    public class DamageBase : MonoBehaviour, IDamageble
    {
        public virtual int Deal(int damage, int amoor, int currentHealth)
        {
            var damageResult = damage - amoor;

            if (damageResult < 0) return currentHealth;

            return currentHealth -= damageResult;
        }
    }
}