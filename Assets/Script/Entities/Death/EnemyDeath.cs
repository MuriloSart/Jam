using System.Collections;
using UnityEngine;

namespace Entities.Death
{
    public class EnemyDeath : DeathBase
    {
        public override void Kill()
        {
            EnemiesManager.Instance.EnemyKilled(entity);
            Destroy(this.gameObject);
        }
    }
}