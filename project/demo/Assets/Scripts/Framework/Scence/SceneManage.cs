using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景类
/// </summary>
public class SceneManage : ModelManage
{
    /// <summary>
    /// 加载场景
    /// </summary>
    public void LoadScene(string name, LoadType loadType, Action fun)
    {
        //清数据 
        if (loadType == LoadType.Asyn)
        {
            mGameManage.StartCoroutine(LoadSceneAsyn(name, fun));
            return;
        }

        SceneManager.LoadScene(name);
        fun.Invoke();
    }
    
    /// <summary>
    /// 异步
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    /// <returns></returns>
    IEnumerator LoadSceneAsyn(string name, Action fun)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        yield return asyncOperation;
        if(asyncOperation.isDone)
            fun.Invoke();
    }
}
