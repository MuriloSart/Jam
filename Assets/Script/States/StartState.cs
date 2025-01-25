public class StartState : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        AlliesManager.Instance.CreateAllies();
        EnemiesManager.Instance.CreateEnemies();
    }
}