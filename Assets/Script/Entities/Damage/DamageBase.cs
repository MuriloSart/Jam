using Entities.Interfaces;
using UnityEngine;

namespace Entities.Damage
{
    public class DamageBase : MonoBehaviour, IDamageble
    {
        public int Deal(int damage, int amoor, int currentHealth)
        {
            var result = damage - amoor;

            if (result < 0) return currentHealth;

            return currentHealth -= result;
        }
    }
}