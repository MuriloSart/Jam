using Entities;

public class StartState : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        AlliesManager.Instance.CreateAllies();
        EnemiesManager.Instance.CreateEnemies();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        foreach(Entity entity in AlliesManager.Instance.queueAnimation.activeAllies)
        {
            entity.startAbility?.Cast();
        }
    }
}