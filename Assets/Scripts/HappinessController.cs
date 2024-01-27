using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class HappinessController : MonoBehaviour
{
    public static HappinessController Instance;
    public event Action<HappinessInfluence> GameOver;
    [SerializeField] private HappinessSlider slider;
    private float _value = 0.5f;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Change(float value)
    {
        _value += value;
        slider.Set(_value);
        if (_value >= 1f)
        {
            GameOver?.Invoke(HappinessInfluence.Positive);
        }
        else if (_value <= 0f)
        {
            GameOver?.Invoke(HappinessInfluence.Negative);
        }
    }
}
