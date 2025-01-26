using System.Diagnostics;
using Entities;

public class GameManager : Singleton<GameManager>
{
    public FSM_Battle battleStates;

    private bool allyAnimationsComplete = false;
    private bool enemiesAnimationsComplete = false;

    private void Update()
    {
        checkingToAttack();
    }

    private void checkingToAttack()
    {
        if (enemiesAnimationsComplete && allyAnimationsComplete)
        {
            AttackState(); 
            allyAnimationsComplete = false;
            enemiesAnimationsComplete = false;
        }
    }

    public void Start()
    {
        AlliesManager.Instance.queueAnimation.OnAllAnimationsComplete += CheckingAllyAnimations;
        EnemiesManager.Instance.queueAnimation.OnAllAnimationsComplete += CheckingEnemiesAnimations;
    }

    private void OnDestroy()
    {
        AlliesManager.Instance.queueAnimation.OnAllAnimationsComplete -= CheckingAllyAnimations;
        EnemiesManager.Instance.queueAnimation.OnAllAnimationsComplete -= CheckingEnemiesAnimations;
    }

    private void CheckingEnemiesAnimations()
    {
        enemiesAnimationsComplete = true;
    }

    private void CheckingAllyAnimations()
    {
        allyAnimationsComplete = true;
    }

    public void StartState()
    {
        battleStates.stateMachine.SwitchState(FSM_Battle.BattleStates.START_STATE);
    }

    public void AttackState()
    {
        battleStates.stateMachine.SwitchState(FSM_Battle.BattleStates.ATTACK_STATE, AlliesManager.Instance.queueAnimation.activeAllies[0], EnemiesManager.Instance.queueAnimation.activeEnemies[0]);
    }

    public void IdleState()
    {
        battleStates.stateMachine.SwitchState(FSM_Battle.BattleStates.IDLE_STATE);
    }
}
