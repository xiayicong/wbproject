using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEndState : State<GameEndState>
{
    public override bool EvaluateCondition(IState preState)
    {
        return true;
    }

    public override void EnterState(FSM fsm, IState preState)
    {
        base.EnterState(fsm, preState);
        GameEntry.instance.FindModel<UIManager>().ShowDialog(UIName.UI3,UIShowType.Add);
        StartCoroutine(ChangeState());
    }

    public IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
