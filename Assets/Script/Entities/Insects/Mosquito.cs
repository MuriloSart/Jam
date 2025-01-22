using UnityEngine;

namespace Entities.Insetos
{
    public class Mosquito : Entity
    {
        public override void Kill()
        {
            base.Kill();
            int randomInt = Random.Range(0, AlliesManager.Instance.allies.Count - 2);
            AlliesManager.Instance.allies[randomInt].damage += 1;
            AlliesManager.Instance.allies[randomInt].health.CurrentLife += 1;
        }
    }
}
