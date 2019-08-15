using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStartState : State<GameStartState>
{

    public override bool EvaluateCondition(IState preState)
    {
        return true;
    }

    public override void EnterState(FSM fsm,IState preState)
    {
        base.EnterState(fsm,preState);
        UIManager.Instance.ShowDialog(UIName.UI1);
        StartCoroutine(ChangeState());
    }

    public IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5.0f);
        m_FsmManager.SwitchState(GamePlayingState.Instance);
    }
}
