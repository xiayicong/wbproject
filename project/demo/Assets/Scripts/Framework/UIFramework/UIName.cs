using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIName
{
    None = 0,
    UI1,
    UI2,
    UI3,
}

public class UIRegister : Singleton<UIRegister>
{
    private static Dictionary<UIName, string> m_UIPath;
    public static void RegisterUI()
    {
        m_UIPath = new Dictionary<UIName, string>
        {
            {UIName.UI1,"UIPrefabs/UIPanel1"},
            {UIName.UI2,"UIPrefabs/UIPanel2"},
            {UIName.UI3,"UIPrefabs/UIPanel3"},
        };
    }

    public static string GetUIPath(UIName name)
    {
        if (m_UIPath == null) return "";
        if(m_UIPath.ContainsKey(name))
        {
            return m_UIPath[name];
        }
        return "";
    }
}
