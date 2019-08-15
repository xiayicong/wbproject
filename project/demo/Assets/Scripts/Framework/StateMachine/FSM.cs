using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : UnitySingleton<FSM>
{
    private IState m_curState;
    private IState m_PreState;

    public void Initialize()
    {
        
    }

    private void Awake()
    {
        SwitchState(GameStartState.Instance);
    }

    public void SwitchState(IState nextState)
    {

        Debug.Log("[FSM][SwitchState] curState:  " + m_curState + "  nextState:  " + nextState);
        if (nextState == null) return;
        if (!nextState.EvaluateCondition(m_curState))
        {
            return;
        }
        nextState.EnterState(this,m_curState);
        if (m_curState != null)
        {
            m_curState.LeaveState(nextState);
        }
        m_PreState = m_curState;
        m_curState = nextState;
    }

    private void Update()
    {
        if(m_curState!=null)
        {
            m_curState.UpdateState();
        }
    }
}
