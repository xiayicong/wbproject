using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using UnityEngine;

public class GameEntry : GameManage
{
    public static GameEntry instance = null;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterAllModel();
        FindModel<TableManage>().LoadConfig();
        InitAllModel();
    }

    /// <summary>
    /// 查找模块
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T FindModel<T>() where T : ModelManage
    {

        return FindModel(typeof(T)) as T;
    }

    // Update is called once per frame
    void Update()
    {
        MainThread();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    
    /// <summary>
    /// 注册所有的模块
    /// </summary>
    protected void RegisterAllModel()
    {
        RegisterModel(new TimeManage());
        RegisterModel(new TableManage());
        RegisterModel(new UIManager());
        RegisterModel(new PlayerManage());
        RegisterModel(new AudioManage());
        RegisterModel(new FSM());
        RegisterModel(new ObjectPool());
        RegisterModel(new ResourManage());
    }

     /// <summary>
    /// 当销毁的时候调用
    /// </summary>
    void OnDestroy()
    {
        Stop();
    }

    void OnApplicationFocus(bool focusStatus){}
}
