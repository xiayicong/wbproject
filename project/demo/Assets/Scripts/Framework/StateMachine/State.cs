using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State<T> : UnitySingleton<T>, IState where T : MonoBehaviour
{
    public StateName m_stateName = StateName.None;
    protected FSM m_FsmManager;

    public virtual void EnterState(FSM fsm,IState preState)
    {
        m_FsmManager = fsm;
    }

    public virtual bool EvaluateCondition(IState preState)
    {
        return false;
    }

    public virtual void LeaveState(IState nextState)
    {

    }

    public virtual void OnMessage()
    {

    }

    public virtual void UpdateState()
    {

    }
}
