using Entities;
using UnityEngine;

public class Aranha : Entity
{
    protected override void Init()
    {
        int randomInt = Random.Range(0, EnemiesManager.Instance.enemies.Count - 2);
        EnemiesManager.Instance.enemies[randomInt].damage -= 1;
    }
}
