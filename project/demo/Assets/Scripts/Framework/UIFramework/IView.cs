using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    
    void OnEnterUI();
    void OnLeaveUI();
    void RegisterEvent();
    void UnRegisterEvent();
}
