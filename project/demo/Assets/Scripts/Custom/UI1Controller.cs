using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI1Controller : UIController
{
    public override void OnEnterUI()
    {
        Debug.Log("界面一 打开");
        base.OnEnterUI();
    }

    public override void OnLeaveUI()
    {
        base.OnLeaveUI();
        Debug.Log("界面一 关闭");
    }
}
