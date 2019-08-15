using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIName
{
    None = 0,
    Login,
}

public class UIRegister: Singleton<UIRegister>
{
    public static Dictionary<UIName, string> m_UIPath;
    public static void RegisterUI()
    {
        m_UIPath = new Dictionary<UIName, string>
        {
            {UIName.Login,"Assets/Prefabs/UI/LoginUI"},
        };
    }
}
