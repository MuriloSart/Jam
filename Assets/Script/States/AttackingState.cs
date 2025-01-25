using System.Collections;
using Entities;
using UnityEngine;
public class AttackingState : StateBase
{
    private Entity enemy;
    private Entity ally;
    bool canAttack = true;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        ally = (Entity)objs[0];
        enemy = (Entity)objs[1];
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if(enemy != null || ally != null)
        {
            if (canAttack)
            {
                canAttack = false;
                CoroutineRunner.Instance.StartCoroutine(Attack());
            }
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        ally = null;
        enemy = null;
    }

    private IEnumerator Attack()
    {
        ally.damageHandler.Deal(ally.Damage, enemy.health);
        enemy.damageHandler.Deal(enemy.Damage, ally.health);
        Result();

        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    private void Result()
    {
        if (ally.health.CurrentLife <= 0)
            ally.death.Kill();
        if (enemy.health.CurrentLife <= 0)
            enemy.death.Kill();
        if(ally.health.CurrentLife <= 0 || enemy.health.CurrentLife <= 0)
            GameManager.Instance.IdleState();
    }
}

