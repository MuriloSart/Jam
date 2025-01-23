using Entities.Abilities;
using Entities.Health;
using Entities.Death;
using UnityEngine;
using System;
using Entities.Damage;
using Entities.Heal;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField]private int damage = 1;
        public int Damage
        {
            get => damage;
            set
            {
                if (value < 0)
                    damage = 0;
                else
                    damage = value;
            }
        }

        [Header("Life Cicles")]
        public HealthBase health;
        public DeathBase death;
        public DamageBase damageHandler;
        public HealBase healHandler;

        [Header("Abilities")]
        [SerializeField] private AbilityBase ability;
        [SerializeField] private AbilityBase startAbility;


        [HideInInspector] public Action<Entity> OnAbilityUsed;

        private void Start()
        {
            Init();
        }

        protected virtual void Init() 
        {
            startAbility?.Cast();
            damageHandler.Initializer(this);
            healHandler.Initializer(this);
        }

        public void UseAbility()
        {
            ability.Cast();
            OnAbilityUsed?.Invoke(this);
        }
    }
}
