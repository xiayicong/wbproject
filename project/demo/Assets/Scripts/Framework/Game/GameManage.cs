using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManage : MonoBehaviour
{

    /// <summary>
    /// 所有的列表
    /// </summary>
    protected Dictionary<Type, ModelManage> mAllModelDic = new Dictionary<Type, ModelManage>();

    /// <summary>
    /// 所有的模块
    /// </summary>
    protected List<ModelManage> mAllModelList = new List<ModelManage>();

    /// <summary>
    /// 添加一个系统管理器
    /// </summary>
    /// <param name="modelManage">模块管理器</param>
    protected void RegisterModel(ModelManage modelManage)
    {
        if (modelManage == null || this.mAllModelDic.ContainsKey(modelManage.GetType()))
            return;
        if (this.mAllModelDic.ContainsKey(modelManage.GetType()) == true)
            return;
        this.mAllModelDic.Add(modelManage.GetType(), modelManage);
        modelManage.SetGameManage(this);
        mAllModelList.Add(modelManage);
    }

    /// <summary>
    /// 查找模块
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ModelManage FindModel(Type type)
    {
        if (!this.mAllModelDic.ContainsKey(type))
            return null;

        return this.mAllModelDic[type];
    }

    /// <summary>
    /// 初始化所有的模块
    /// </summary>
    protected void InitAllModel()
    {
        foreach (ModelManage modelManage in mAllModelList)
        {
            modelManage.Init();
        }
    }

    /// <summary>
    /// 主线程调用
    /// </summary>
    protected void MainThread()
    {
        for (int nIndex = 0; nIndex < mAllModelList.Count; ++nIndex)
        {
            mAllModelList[nIndex].MainThread();
        }
    }

    /// <summary>
    /// 停止
    /// </summary>
    protected void Stop()
    {
        foreach (ModelManage modelManage in mAllModelList)
        {
            modelManage.Stop();
        }
    }
}

