using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public enum LoadType
{
    Syn = 0,
    Asyn = 1
}

public class ResourManage : ModelManage
{
    /// <summary>
    /// 加载预设体
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <param name="loadType"></param>
    /// <param name="fun"></param>
    public void LoadGameObject(string path, Transform parent, LoadType loadType, Action<GameObject> fun)
    {
        LoadAsset(path, loadType, (obj) =>
        {
            GameObject m_obj = GameObject.Instantiate(obj as GameObject);
            if(parent != null)
                m_obj.transform.SetParent(parent);
            m_obj.transform.localPosition = Vector3.zero;
            m_obj.transform.localEulerAngles = Vector3.zero;
            m_obj.transform.localScale = Vector3.one;
            fun.Invoke(m_obj);
        });
    }
    
    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="path"></param>
    /// <param name="loadType"></param>
    /// <param name="fun"></param>
    public void LoadAsset(string path, LoadType loadType, Action<object> fun)
    {
        if (loadType == LoadType.Syn)
            LoadSyn(path, fun);
        if (loadType == LoadType.Asyn)
            mGameManage.StartCoroutine(LoadAsyn(path, fun));
    }

    private void LoadSyn(string path, Action<object> fun)
    {
        Object obj = Resources.Load(path);
        if (obj != null)
        {
            fun.Invoke(obj);
        }
    }
    
    private IEnumerator LoadAsyn(string path, Action<object> fun)
    {
        ResourceRequest request = Resources.LoadAsync(path);
        yield return request;
        if (request != null)
        {
            if (request.isDone)
            {
                fun.Invoke(request.asset);
            }
        }
    }
}
