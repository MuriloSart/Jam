using UnityEngine;
using Entities.Health;
using System.Collections;
using Entities.Interfaces;

namespace Entities
{
    public class Entity : MonoBehaviour, IKillable
    {
        [Header("Stats")]
        public int damage = 1;

        [Header("References")]
        public HealthBase health;

        private void Start()
        {
            Init();
        }

        protected virtual void Init() { }

        public virtual void Kill()
        {
            Destroy(this);
        }
    }
}
