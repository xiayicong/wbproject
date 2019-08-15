using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindExistingInstance() ?? CreateNewInstance();
            }
            return _instance;
        }
    }

    private static T FindExistingInstance()
    {
        T[] existingInstances = FindObjectsOfType<T>();

        if (existingInstances == null || existingInstances.Length == 0) return null;

        return existingInstances[0];
    }

    private static T CreateNewInstance()
    {
        var containerGO = new GameObject(typeof(T).Name + " (Singleton)");
        return containerGO.AddComponent<T>();
    }

    protected virtual void SingletonAwakened() { }

    void Awake()
    {
        T[] thisInstances = this.GetComponents<T>();

        if (_instance == null)
        {
            _instance = thisInstances[0];
            DontDestroyOnLoad(_instance.gameObject);
        }
        else 
        {
            for (int i = 0; i < thisInstances.Length; i++)
            {
                if (thisInstances[i] != _instance)
                {
                    DestroyImmediate(this);
                    return;
                }
            }
        }

        SingletonAwakened();
    }
}
