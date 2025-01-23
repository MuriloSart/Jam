using Entities;
public class AttackingState : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        var Ally = (Entity)objs[0];
        var Enemy = (Entity)objs[1];

        Ally.damageHandler.Deal(Ally.Damage, Enemy);
        Enemy.damageHandler.Deal(Enemy.Damage, Ally);
    }
}
