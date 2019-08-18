using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Xml;

public class TableManage : ModelManage
{   
    /// <summary>
    /// P配置表路径
    /// </summary>
    private readonly string configPath = "Configs";
    
    /// <summary>
    /// 读表数据类
    /// </summary>
    private Dictionary<Type, BaseData> m_AllData =new Dictionary<Type, BaseData>();
    
    /// <summary>
    /// 数据表
    /// </summary>
    private Dictionary<string, List<TextData>> m_data =new Dictionary<string, List<TextData>>();
    
    /// <summary>
    /// 初始化注册数据
    /// </summary>
    protected override void OnInit()
    {
        m_AllData.Add(typeof(TextData), new TextData());
    }
    
    /// <summary>
    /// load
    /// </summary>
    public void LoadConfig()
    {
        LoadXml<TextData>((list) =>
        {
            m_data.Add(typeof(TextData).Name, list);
        });
    }
    
    /// <summary>
    /// 取数据
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<TextData> GetData(string name)
    {
        List<TextData> data;
        m_data.TryGetValue(name, out data);
        return data;
    }
    
    /// <summary>
    /// loadxml
    /// </summary>
    /// <param name="fun"></param>
    /// <typeparam name="T"></typeparam>
    private void LoadXml<T>(Action<List<T>> fun) where T : BaseData
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(XmlReader.Create((Application.dataPath+"/Configs/" + typeof(T).Name + ".xml")));
        XmlNodeList xmlNodeList = xml.SelectSingleNode("config").ChildNodes;
        List<T> list = new List<T>();
        //遍历所有子节点
        foreach(XmlElement node in xmlNodeList)
        {
            try
            {
                T data = m_AllData[typeof(T)] as T;
                FieldInfo[] fields = typeof(T).GetFields();
                foreach (FieldInfo field in fields)
                {
                    field.SetValue(data, node.GetAttribute(field.Name));
                }
                list.Add(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("读表异常！！！！！！！！！" +e);
                throw;
            }
        }

        fun.Invoke(list);
    }
}
