using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 时间管理
/// </summary>
public class TimeManage : ModelManage {
    
    Dictionary<string, TimerEvent> mAllTimerEvents =new Dictionary<string, TimerEvent>();
    
    /// <summary>
    /// 当前时间戳
    /// </summary>
    protected long mCurTimestamp = 0;

    /// <summary>
    /// 主线程
    /// </summary>
    public override void MainThread()
    {
        CalcTimestamp();
    }

    /// <summary>
    /// 获取本地时间戳
    /// </summary>
    /// <returns></returns>
    public long GetLocalTime()
    {
        return (DateTime.Now.Ticks)/10000;
    }

    /// <summary>
    /// 获取当前时间
    /// </summary>
    /// <returns></returns>
    public long GetTimestamp()
    {
        return this.mCurTimestamp;
    }

    /// <summary>
    /// 获取日期相关的对象
    /// </summary>
    /// <returns></returns>
    public DateTime GetDataTime()
    {
        return TimestampToDateTime(this.mCurTimestamp);
    }

    /// <summary>
    /// 时间戳转化为日期对象
    /// </summary>
    /// <param name="ticks"></param>
    /// <returns></returns>
    public DateTime TimestampToDateTime(long ticks)
    {
        return new DateTime(ticks);
    }

    /// <summary>
    /// 计算时间事件
    /// </summary>
    private void CalcTimestamp()
    {
        foreach (var item in mAllTimerEvents)
        {
            if(!item.Value.isGo)
                continue;
            if(GetTimestamp() - item.Value.mStartTime > item.Value.mTimeLong)
                item.Value.endFun.Invoke();
        }
    }
    
    /// <summary>
    /// 倒计时事件
    /// </summary>
    /// <param name="timeEvent"></param>
    public void AddTimerEvent(string name, TimerEvent timeEvent)
    {
        if(mAllTimerEvents.ContainsKey(name))
            return;
        timeEvent.mStartTime = GetTimestamp();
        mAllTimerEvents.Add(name, timeEvent);
    }
    
    public void RemoveimerEvent(string name)
    {
        if(!mAllTimerEvents.ContainsKey(name))
            return;
        mAllTimerEvents.Remove(name);
    }
}
