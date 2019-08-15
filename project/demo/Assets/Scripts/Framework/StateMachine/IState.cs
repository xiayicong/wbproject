using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    bool EvaluateCondition(IState preState);
    void EnterState(FSM fsm,IState preState);
    void UpdateState();
    void LeaveState(IState nextState);
    void OnMessage();
}
