using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _xAxisMovement;
    private Vector3 _inputVector;

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
        _inputVector.x = Mathf.Clamp(_inputVector.x, -3f, 3f);
        transform.position += _inputVector  * Time.deltaTime;
    }

    private void SetValue(float value)
    {
        Debug.Log($"value {value}");
        _inputVector.x = value;
    }
}
