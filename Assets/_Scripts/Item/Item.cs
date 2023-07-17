using MyUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Itemtype _itemType;

    [SerializeField] private string _poolKey;

    [SerializeField] private float _activeTimer;

    private float _decayTimer;

    public Itemtype itemType
    {
        get => _itemType;
    }

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
            Debug.Log("Player hit!");
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
        ReturnItem();
    }

    private void ReturnItem()
    {
        PooledObjectItem.ReturnToPool(_poolKey, this.gameObject);
    }
}
