using Entities.Interfaces;
using UnityEngine;

namespace Entities.Death
{
    public class DeathBase : MonoBehaviour, IKillable
    {
        public virtual void Kill()
        {
            Destroy(this);
        }
    }
}