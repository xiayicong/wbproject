using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIShowType
{
    Normal = 0,
    Add
}

public class UIManager : UnitySingleton<UIManager>, IManager
{
    public Transform[] m_UILayers;
    public Transform m_cacheLayer;
    [HideInInspector]
    public UIController m_curUIController;
    private int m_iCurUILayer = 0;
    private int m_iLayerCapacity = 5;
    private Dictionary<int, List<UIName>> m_LayerManager = new Dictionary<int, List<UIName>>();
    private Dictionary<UIName, UIController> m_rgCacheUIController = new Dictionary<UIName, UIController>();
    private Stack<UIController> m_rgDialogStack = new Stack<UIController>();
    public void Init()
    {
        m_iCurUILayer = 0;
        m_curUIController = null;
    }

    public void ShowDialog(UIName dialogName, UIShowType showType = UIShowType.Normal)
    {
        AssignLayer(showType);
        GameObject dialogObject = null;
        if (m_rgCacheUIController != null)
        {
            if (m_rgCacheUIController.ContainsKey(dialogName)) dialogObject = m_rgCacheUIController[dialogName].gameObject;
        }
        if (dialogObject == null)
        {
            string uiprefabpath = UIRegister.GetUIPath(dialogName);
            if (!string.IsNullOrEmpty(uiprefabpath))
            {
                GameObject uiprefab = Resources.Load<GameObject>(uiprefabpath);
                dialogObject = GameObject.Instantiate(uiprefab, Vector3.zero, Quaternion.identity, m_UILayers[m_iCurUILayer]);
                dialogObject.SetActive(false);
            }
        }
        UIController tmp = dialogObject.GetComponent<UIController>();
        if (tmp == null)
        {
            Debug.Log("UI Root Node Can Not Find UIController! UIName:  " + dialogName);
            return;
        }
        if (!m_rgCacheUIController.ContainsKey(dialogName))
        {
            m_rgCacheUIController.Add(dialogName, tmp);
        }
        OnShowDialog(tmp,showType);
    }

    public void CloseDialog(UIName closeDialog)
    {
        if (m_curUIController == null) return;
        m_curUIController.UnRegisterEvent();
        m_curUIController.OnLeaveUI();
        m_curUIController.transform.parent = m_cacheLayer;
        m_curUIController.gameObject.SetActive(false);
        m_rgDialogStack.Pop();
        m_curUIController = m_rgDialogStack.Peek();
    }

    private void AssignLayer(UIShowType showType)
    {
        if (m_curUIController == null)
        {
            m_iCurUILayer = 0;
            return;
        }
        if (m_curUIController != null) m_iCurUILayer = m_curUIController.m_iLayer;
        else m_iCurUILayer = 0;
        switch (showType)
        {
            case UIShowType.Add:
                int count = GetCapacity(m_iCurUILayer);
                if (count > m_iLayerCapacity)
                {
                    m_iCurUILayer = Mathf.Min(m_iCurUILayer + 1, m_UILayers.Length);
                }
                break;
        }
    }

    private void OnShowDialog(UIController showUIController, UIShowType showtype)
    {
        switch (showtype)
        {
            case UIShowType.Normal:
                if (m_curUIController != null)
                {
                    m_curUIController.UnRegisterEvent();
                    m_curUIController.OnLeaveUI();
                    m_curUIController.m_iLayer = -1;
                    m_curUIController.transform.parent = m_cacheLayer;
                    m_curUIController.gameObject.SetActive(false);
                    m_rgDialogStack.Pop();
                }
                break;
        }
        m_curUIController = showUIController;
        m_curUIController.m_iLayer = m_iCurUILayer;
        m_curUIController.RegisterEvent();
        m_curUIController.OnEnterUI();
        m_curUIController.gameObject.SetActive(true);
        m_rgDialogStack.Push(showUIController);
    }

    private int GetCapacity(int layer)
    {
        if (m_LayerManager == null)
        {
            return 0;
        }
        if (m_LayerManager.ContainsKey(layer))
        {
            int count = m_LayerManager[layer].Count;
            return count;
        }
        return 0;
    }
}
