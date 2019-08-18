using System.Collections.Generic;
using UnityEngine;

namespace Framework.Common
{
    /// <summary>
    /// 对象池 暂时没有脚本机制
    /// </summary>
    public class ObjectPool : ModelManage
    {
        private Transform root;
        
        private Dictionary<string, Queue<object>> objectPool = new Dictionary<string, Queue<object>>();

        protected override void OnInit()
        {
            root = GameObject.Find("ObjectPool").transform;
            GameObject.DontDestroyOnLoad(root);
        }
        
        /// <summary>
        /// 注册对象池
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        public void RegisterPool(string path, int count)
        {
            if(objectPool.ContainsKey(path))
                return;
            Queue<object> queue = new Queue<object>();
            for (int i = 0; i < count; i++)
            {
                FindModel<ResourManage>().LoadGameObject(path, root, LoadType.Syn, (obj) =>
                {
                    obj.SetActive(false);
                    queue.Enqueue(obj);
                });
            }
            objectPool.Add(path, queue);
        }
        
        /// <summary>
        /// 取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject PushOne(string path)
        {
            if(!objectPool.ContainsKey(path))
                return null;
            Queue<object> pool = objectPool[path];
            GameObject m_obj = null;
            if (pool.Count == 0)
            {
                FindModel<ResourManage>().LoadGameObject(path, root, LoadType.Syn, (obj) =>
                {
                    m_obj = obj;
                });
                return m_obj;
            }
            m_obj = pool.Dequeue() as GameObject;
            m_obj.SetActive(true);
            return m_obj;
        }
        
        /// <summary>
        /// 进
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public void PullOne(string path, GameObject obj)
        {
            if(!objectPool.ContainsKey(path))
                return;
            objectPool[path].Enqueue(obj);
        }
        
        /// <summary>
        /// 删除池
        /// </summary>
        /// <param name="path"></param>
        public void DeletePool(string path)
        {
            if(!objectPool.ContainsKey(path))
                return;
            Queue<object> pool = objectPool[path];
            while (pool.Count > 0)
            {
                GameObject.Destroy(pool.Dequeue() as GameObject);
            }

            objectPool.Remove(path);
        }
    }
}