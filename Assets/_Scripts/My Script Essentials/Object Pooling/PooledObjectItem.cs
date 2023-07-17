using System.Collections.Generic;
using UnityEngine;

namespace MyUtilities
{
    public static class PooledObjectItem
    {
        private static Dictionary<string, ObjectPool> pooledDictionary = new Dictionary<string, ObjectPool>();

        public static void Add(string key, GameObject item, GameObject parent, int amtOfCopies = 10, bool expandable = true, bool status = false, bool clearOnDisable = true)
        {
            pooledDictionary.Add(key, new ObjectPool(item, parent, amtOfCopies, expandable, status, clearOnDisable));
        }

        public static GameObject GetObject(string key)
        {
            return pooledDictionary.TryGetValue(key, out var pool) ? pool.GetObject() : null;
        }

        public static void ReturnToPool(string key, GameObject returnObject)
        {
            if (pooledDictionary.TryGetValue(key, out var pool))
            {
                pool.ReturnToPool(returnObject);
            }
        }
    }
}