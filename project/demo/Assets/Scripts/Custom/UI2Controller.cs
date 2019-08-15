using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI2Controller : UIController
{
    public override void OnEnterUI()
    {
        Debug.Log("界面2 打开");
        base.OnEnterUI();
    }

    public override void OnLeaveUI()
    {
        base.OnLeaveUI();
        Debug.Log("界面2 关闭");
    }
}
