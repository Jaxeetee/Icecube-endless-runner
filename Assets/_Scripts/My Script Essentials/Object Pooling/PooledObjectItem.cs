using System.Collections.Generic;
using UnityEngine;

namespace MyUtilities.InheritPool
{
    public class PooledObjectItem : MonoBehaviour
    {
        [Header("Object Pooling")]
        [SerializeField] private int _numberOfCopies;

        [SerializeField] private bool _expandable;

        [SerializeField] private bool _enableOnInstantiate;

        [SerializeField] private bool _clearOnDisable;

        [SerializeField] private Transform _parent;

        private ObjectPool _pool;

        protected virtual void Start()
        {
            _pool = new ObjectPool(this.gameObject, _parent.gameObject,_numberOfCopies, _expandable, _enableOnInstantiate, _clearOnDisable);
        }

        protected GameObject GetObject()
        {
            return _pool.GetObject();
        }

        protected void ReturnToPool(GameObject pooledObject)
        {
            _pool.ReturnToPool(pooledObject);
        }

    }
}
//public static class PooledObjectItem
//{
//    private static Dictionary<string, ObjectPool> pooledDictionary = new Dictionary<string, ObjectPool>();

//    public static void Add(string key, GameObject item, GameObject parent, int amtOfCopies = 10, bool expandable = true, bool status = false, bool clearOnDisable = true)
//    {
//        pooledDictionary.Add(key, new ObjectPool(item, parent, amtOfCopies, expandable, status, clearOnDisable));
//    }

//    public static GameObject GetObject(string key)
//    {
//        return pooledDictionary.TryGetValue(key, out var pool) ? pool.GetObject() : null;
//    }

//    public static void ReturnToPool(string key, GameObject returnObject)
//    {
//        if (pooledDictionary.TryGetValue(key, out var pool))
//        {
//            pool.ReturnToPool(returnObject);
//        }
//    }
//}