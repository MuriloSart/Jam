using Entities.Interfaces;
using UnityEngine;

namespace Entities.Death
{
    public abstract class DeathBase : MonoBehaviour, IKillable
    {
        protected Entity entity;
        private void Start()
        {
            entity = GetComponent<Entity>();
        }

        public abstract void Kill();
    }
}