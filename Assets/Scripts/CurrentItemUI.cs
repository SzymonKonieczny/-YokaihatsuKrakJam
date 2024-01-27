using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentItemUI : MonoBehaviour
{
    public static CurrentItemUI Instance;
    [SerializeField] private TextMeshProUGUI label;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Set(ItemID id)
    {
        label.text = id.ToString();
    }
}
