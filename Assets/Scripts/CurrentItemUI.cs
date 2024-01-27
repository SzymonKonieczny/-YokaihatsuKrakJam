using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentItemUI : MonoBehaviour
{
    public static CurrentItemUI Instance;
    [SerializeField] private TextMeshProUGUI pannaLabel;
    [SerializeField] private TextMeshProUGUI tesciowaLabel;

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Set(ItemID id, PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Panna:
                pannaLabel.text = $"Panna: {id}";
                break;
            case PlayerType.Tesciowa:
                tesciowaLabel.text = $"Teściowa: {id}";
                break;
        }
    }
}
