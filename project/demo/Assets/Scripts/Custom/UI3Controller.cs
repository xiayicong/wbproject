using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3Controller : UIController
{
    public override void OnEnterUI()
    {
        Debug.Log("界面3 打开");
        base.OnEnterUI();
    }

    public override void OnLeaveUI()
    {
        base.OnLeaveUI();
        Debug.Log("界面3 关闭");
    }
}
