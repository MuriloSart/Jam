using UnityEngine;
using Entities.Damage;
using Entities.Heal;

namespace Entities.Health
{
    public class HealthBase: MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private DamageBase damageHandler;
        [SerializeField] private HealBase healHandler;

        [Header("Start Life")]
        public int startLife = 1;

        [Header("Armor")]
        [SerializeField] private int _currentArmor = 0;
        public int CurrentArmor
        {
            get => _currentArmor;
            set
            {
                if (value < 0)
                    _currentArmor = 0;
                else
                    _currentArmor = value;
            }
        }

        public int CurrentLife
        {
            get => CurrentLife;
            private set
            {
                if (value < 0)
                    CurrentLife = 0;
                else
                    CurrentLife = value;
            }
            
            
        }

        private void Start()
        {
            CurrentLife = startLife;
        }

        public virtual void Damage(int damage)
        {
            damageHandler.Deal(damage, _currentArmor, CurrentLife);
        }

        public virtual void Heal(int heal)
        {
            healHandler.Restore(heal, CurrentLife);
        }
    }
}