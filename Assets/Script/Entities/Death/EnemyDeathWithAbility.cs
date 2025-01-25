using System.Collections;
using Entities.Death;
using UnityEngine;

namespace Assets.Script.Entities.Death
{
    public class EnemyDeathWithAbility : DeathBase
    {
        public override void Kill()
        {
            EnemiesManager.Instance.EnemyKilled(entity);
            Destroy(this.gameObject);
            entity.UseAbility();
        }
    }
}