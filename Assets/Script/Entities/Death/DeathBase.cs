using Entities.Interfaces;
using UnityEngine;

namespace Entities.Death
{
    public class DeathBase : MonoBehaviour, IKillable
    {
        protected Entity entity;
        private void Start()
        {
            entity = GetComponent<Entity>();
        }

        public virtual void Kill()
        {
            Destroy(this);
            AlliesManager.Instance.AllyKilled(entity);
        }
    }
}