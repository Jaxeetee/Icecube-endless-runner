using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float _maxSpawnInterval;

    [SerializeField] private float _maxItemSpeed;

    [SerializeField] private float _decayRate;

    public GameState _currentGameState;


    private float _currentInterval;

    public float _currentItemSpeed;

    public static event Action<float> OnItemSpawn;

    public static event Action OnSpawnInterval;


    private void Start()
    {
        _currentInterval = _maxSpawnInterval;
        _currentItemSpeed = _maxItemSpeed;
    }

    private void Update()
    {
        _currentItemSpeed -= _decayRate * Time.deltaTime;
        _currentItemSpeed = Mathf.Clamp(_currentItemSpeed, 1f, _maxItemSpeed);

        if (_currentItemSpeed < 0f) return; 


        if (Time.time > _currentInterval)
        {

            OnSpawnInterval?.Invoke();
            OnItemSpawn?.Invoke(_currentItemSpeed);
            _currentInterval = Time.time + _maxSpawnInterval;
        }

    }

}
