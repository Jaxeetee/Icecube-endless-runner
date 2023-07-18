using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private PlayerControlAsset _inputs;

    public static event Action<float> OnPlayerMove;
    private void Awake()
    {
        _inputs = new PlayerControlAsset();
    }

    private void OnEnable()
    {
        SwitchCurrentActionMap(StringManager.ACTIONMAP_MAINGAME);
        EnableActionMapMainGame();
    }

    private void Start()
    {
    }

    // just in case I have to make a new action map
    public void SwitchCurrentActionMap(string mapName)
    {
        foreach (var action in _inputs.asset.actionMaps)
        {
            action.Disable();
        }
        _inputs.asset.FindActionMap(mapName).Enable();
    }

    private void EnableActionMapMainGame()
    {
        Debug.Log("Enabled");
        InputActionMap inputActions = _inputs.MainGame;

        inputActions.FindAction(StringManager.INPUT_SIDEMOVEMENT).performed += ctx =>
        {
            float value = ctx.ReadValue<float>();
            Debug.Log($"{value}");
            OnPlayerMove?.Invoke(value);
        };
        
        inputActions.FindAction(StringManager.INPUT_SIDEMOVEMENT).canceled += ctx =>
        {
            float value = ctx.ReadValue<float>();
            Debug.Log($"{value}");
            OnPlayerMove?.Invoke(value);
        };
    }
}
