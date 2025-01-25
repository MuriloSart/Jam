using UnityEngine;

public class FSM_Battle : MonoBehaviour
{
    public enum BattleStates
    {
        START_STATE,
        IDLE_STATE,
        ATTACK_STATE
    }

    public StateMachine<BattleStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<BattleStates>();
        stateMachine.Init();

        stateMachine.RegisterStates(BattleStates.START_STATE, gameObject.AddComponent<StartState>());
        stateMachine.RegisterStates(BattleStates.IDLE_STATE, gameObject.AddComponent<IdleState>());
        stateMachine.RegisterStates(BattleStates.ATTACK_STATE, gameObject.AddComponent<AttackingState>());
        stateMachine.SwitchState(BattleStates.START_STATE);
    }

    private void Update()
    {
        stateMachine.Update();
    }

}
