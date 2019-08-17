using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayingState : State<GamePlayingState>
{
    public override bool EvaluateCondition(IState preState)
    {
        return true;
    }

    public override void EnterState(FSM fsm,IState preState)
    {
        base.EnterState(fsm, preState);
        GameEntry.instance.FindModel<UIManager>().ShowDialog(UIName.UI2);
        StartCoroutine(ChangeState());
    }

    public IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(3.0f);
        m_FsmManager.SwitchState(GameEndState.Instance);
    }
}
