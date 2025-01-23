using UnityEngine;

namespace Entities.Health
{
    public class HealthBase: MonoBehaviour
    {
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

        private int _currentLife;

        public int CurrentLife
        {
            get => _currentLife;
            private set
            {
                if (value < 0)
                    _currentLife = 0;
                else
                    _currentLife = value;
            }
            
            
        }

        private void Start()
        {
            _currentLife = startLife;
        }

        public virtual void Damage(int damage)
        {
            if (damage < 0) return;
            _currentLife -= damage;
        }

        public virtual void Heal(int heal)
        {
            if (heal < 0) return;
            _currentLife += heal;
        }
    }
}