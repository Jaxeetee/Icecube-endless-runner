using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private static float _lifePoints;
    public static void GetLifePoints(float value)
    {
        _lifePoints = value;
    }

    public void OnChangeValue(float value)
    {
        _slider.value = value;
    }
}
