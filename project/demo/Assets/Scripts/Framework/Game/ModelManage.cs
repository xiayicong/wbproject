using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ModelManage : IManager
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    protected GameManage mGameManage = null;

    /// <summary>
    /// 设置游戏管理类
    /// </summary>
    /// <param name="gameManage"></param>
    public void SetGameManage(GameManage gameManage)
    {
        this.mGameManage = gameManage;
    }

    /// <summary>
    /// 获取游戏管理类
    /// </summary>
    /// <returns></returns>
    protected GameManage GetGameManage()
    {
        return this.mGameManage;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        OnInit();
    }

    /// <summary>
    /// 初始化时候调用
    /// </summary>
    protected virtual void OnInit() { }


    /// <summary>
    /// 心跳
    /// </summary>
    public virtual void MainThread()
    {

    }

    /// <summary>
    /// 停止
    /// </summary>
    public virtual void Stop()
    {

    }

    /// <summary>
    /// 查找模块
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T FindModel<T>() where T : ModelManage
    {
        return mGameManage.FindModel(typeof(T)) as T;
    }
}
