using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyUtilities
{
    public class ObjectPool
    {
        private string _poolName;
        private GameObject _item;
        private int _amtOfCopies;
        private bool _expandable;
        /// <summary>
        /// should the item be set active true upon calling?
        /// </summary>
        private bool _status;
        /// <summary>
        /// copies will be deleted once the object has been disabled
        /// </summary>
        private bool _clearOnDisable;

        private Queue<GameObject> _copies;
        private GameObject _parent;

        public ObjectPool(GameObject item, GameObject parent, int amtOfCopies = 10, bool expandable = true, bool status = false, bool clearOnDisable = true)
        {
            this._poolName = $"{item.name}(Clone)";
            this._item = item;
            this._amtOfCopies = amtOfCopies;
            this._expandable = expandable;
            this._status = status;
            this._clearOnDisable = clearOnDisable;
            this._parent = parent;
            _copies = new Queue<GameObject>();
            CreateCopies(this._amtOfCopies, this._status);
        }


        private void CreateCopies(int amtOfCopies, bool status)
        {
            if (_parent == null)
            {
                Debug.LogWarning("There's no main parent pool");
                _parent = new GameObject();
                _parent.name = $"{_item.name} pool";
            }


            for (int i = 0; i < amtOfCopies; i++)
            {
                GameObject copy = Object.Instantiate(_item) as GameObject;
                copy.SetActive(status);
                _copies.Enqueue(copy);
                copy.transform.SetParent(_parent.transform);
            }
        }

        public GameObject GetObject()
        {
            if (this._expandable && _copies.Count == 0)
            {
                CreateCopies(_amtOfCopies, _status);
            }
            GameObject toUse = _copies.Dequeue();
            toUse.SetActive(true);
            toUse.transform.rotation = Quaternion.identity;
            toUse.transform.SetParent(null);
            return toUse;
        }

        private bool BelongToPool(GameObject checkObject)
        {
            return $"{ _item.name}(Clone)" == checkObject.name;
        }

        public void ReturnToPool(GameObject returnObject)
        {
            if (!BelongToPool(returnObject))
            {
                Debug.LogError($"{returnObject.name} doesn't belong to this pool or doesn't have instanced pool");
                return;
            }
            returnObject.SetActive(false);
            _copies.Enqueue(returnObject);
            returnObject.transform.SetParent(_parent.transform);
        }

        public void Disable()
        {
            if (!_clearOnDisable) return;

            foreach(var copy in _copies)
            {
                GameObject.Destroy(copy);
            }
            _copies.Clear();
        }
    }
}