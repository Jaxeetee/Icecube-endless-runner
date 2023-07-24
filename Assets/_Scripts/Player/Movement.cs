using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _xAxisMovement;
    private Vector3 _inputVector;

    public float _speed;

    private void OnEnable()
    {
        InputHandler.OnPlayerMove += SetValue;
    }

    private void OnDisable()
    {
        InputHandler.OnPlayerMove -= SetValue;   
    }

    void Update()
    {
        
        transform.position += _inputVector * Time.deltaTime;
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -3f, 3f), transform.position.y, transform.position.z);
    }

    private void SetValue(float value)
    {
        Debug.Log($"value {value}");
        _inputVector.x = value;
    }
}
