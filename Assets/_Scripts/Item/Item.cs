using MyUtilities;
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("DEBUGGING")]
    [SerializeField] private bool _enableDebugger;

    [SerializeField] private string _poolKey;

    [SerializeField] private float _activeTimer;

    private float _decayTimer;

    private float _itemSpeed;


    private void OnEnable()
    {
        GameManager.OnItemSpawn += SetSpeed;
        StartCoroutine(StartTimer());
    }

    private void OnDisable()
    {
        GameManager.OnItemSpawn -= SetSpeed;
    }

    void Update()
    {
        transform.Translate(transform.forward * _itemSpeed * Time.deltaTime, Space.World);
    }

    private void SetSpeed(float speed)
    {
        _itemSpeed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Log("Collided to player");
            ReturnItem();
        }
    }

    private IEnumerator StartTimer()
    {
        _decayTimer = _activeTimer;
        while (_decayTimer > 0)
        {
            _decayTimer -= Time.deltaTime;
            yield return null;
        }
        Log("Item Decayed");
        ReturnItem();
    }

    private void ReturnItem()
    {
        Log($"Item {this.name} returned to pool {_poolKey}");
        PooledObjectItem.ReturnToPool(_poolKey, this.gameObject);
    }


    #region DEBUGGING
    private void Log(string msg)
    {
        if (!_enableDebugger) return;

        Debug.Log(msg);
    }

    private void LogWarning(string msg)
    {
        if (!_enableDebugger) return;

        Debug.LogWarning(msg);
    }

    private void LogError(string msg) 
    {
        if (!_enableDebugger) return;

        Debug.LogError(msg);
    }


    #endregion
}
