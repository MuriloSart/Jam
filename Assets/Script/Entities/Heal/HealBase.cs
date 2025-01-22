using Entities.Interfaces;
using UnityEngine;

namespace Entities.Heal
{
    public class HealBase : MonoBehaviour, IHealable
    {
        public int Restore(int heal, int currentHealth)
        {
            if (heal < 0) return currentHealth;

            return currentHealth += heal;
        }
    }
}