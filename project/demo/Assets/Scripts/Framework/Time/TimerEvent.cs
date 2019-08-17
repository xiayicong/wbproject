using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEvent
{
    /// <summary>
    /// 持续时间
    /// </summary>
    public long mTimeLong = 0;
    
    /// <summary>
    /// 继续标识
    /// </summary>
    public bool isGo = true;
    
    /// <summary>
    /// 回调
    /// </summary>
    public delegate void endFunction();
}
