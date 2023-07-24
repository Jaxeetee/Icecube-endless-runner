using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxlife = 100f;
    [SerializeField] private float _decayRate = 3f;

    [SerializeField] private float _healthIncreasePoints = 5f;
    [SerializeField] private float _damageReceivedPoints = 5f;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = _maxlife;
    }

    void Update()
    {
        _currentHealth -= _decayRate * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collided = other.gameObject;
        if (collided.CompareTag(StringManager.ITEM_ICE))
        {
            _currentHealth += _healthIncreasePoints;
        }
        else if (collided.CompareTag(StringManager.ITEM_OBSTACLE))
        {
            _currentHealth -= _damageReceivedPoints;
        }
    }
}
