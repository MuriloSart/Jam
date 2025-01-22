using System;
using UnityEngine;
using Entities.Damage;
using Entities.Heal;

namespace Entities.Health
{
    public class HealthBase: MonoBehaviour
    {

        [Header("References")]
        public DamageBase damageHandler;
        public HealBase healHandler;

        [Header("Max Health Possible")]
        public int maxHealth = 1;

        [Header("Armor")]
        [SerializeField] private int _currentArmor = 0;
        public int CurrentArmor
        {
            get => _currentArmor;
            set
            {
                if (value < 0)
                    _currentArmor = 0;
                else if (value > maxHealth)
                    _currentArmor = maxHealth;
                else
                    _currentArmor = value;
            }
        }

        private int _currentLife;
        public int CurrentLife
        {
            get => _currentLife;
            set
            {
                if (value < 0)
                    _currentLife = 0;
                else if (value > maxHealth)
                    _currentLife = maxHealth;
                else
                    _currentLife = value;
            }
        }

        private void Start()
        {
            _currentLife = maxHealth;
        }

        public virtual void Damage(int damage)
        {
            try
            {
                damageHandler.Deal(damage, _currentArmor, _currentLife);
            }
            catch (NullReferenceException ex)
            {
                Debug.LogError("DamageHandler não foi inicializado, mensagem do erro: " + ex.Message);
                throw;
            }
        }

        public virtual void Heal(int heal)
        {
            try
            {
                healHandler.Restore(heal, _currentLife);
            }
            catch (NullReferenceException ex)
            {
                Debug.LogError("HealHandler não foi inicializado, mensagem do erro: " + ex.Message);
                throw;
            }
        }
    }
}