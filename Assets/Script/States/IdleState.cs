using System.Collections;
using UnityEngine;

public class IdleState : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        CoroutineRunner.Instance.StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        AlliesManager.Instance.queueAnimation.VerifyAndReorganize();
        yield return new WaitForSeconds(1);
        EnemiesManager.Instance.queueAnimation.VerifyAndReorganize();
        yield return new WaitForSeconds(1);
    }
}