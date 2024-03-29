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
    private Type _currentType = Type.Neutral;
    private static float elapsedTime = 0;
    
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void Change(float value)
    {
        _value += value * elapsedTime * 0.03f * -1f;
        slider.Set(_value);
        if (_value >= 1f)
        {
            GameOver?.Invoke(HappinessInfluence.Negative);
        }
        else if (_value <= 0f)
        {
            GameOver?.Invoke(HappinessInfluence.Positive);
        }

        if (_value < 0.5f && _currentType != Type.Negative)
        {
            MusicManager.Instance.PlayMusic(PlayerType.Tesciowa);
            _currentType = Type.Negative;
        }
        if (_value > 0.5f && _currentType != Type.Positive)
        {
            MusicManager.Instance.PlayMusic(PlayerType.Panna);
            _currentType = Type.Positive;
        }
    }

    public enum Type
    {
        Negative,
        Neutral,
        Positive
    }
}
