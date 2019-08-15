using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour, IView
{
    public UIName m_UIName = UIName.None;
    [HideInInspector]
    public int m_iLayer = -1;
    public virtual void OnEnterUI()
    {
        
    }

    public virtual void OnLeaveUI()
    {
        
    }

    public virtual void RegisterEvent()
    {
       
    }

    public virtual void UnRegisterEvent()
    {
        
    }
}
