using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItemUI : MonoBehaviour
{
    public static CurrentItemUI Instance;
    [SerializeField] private Image pannaImage;
    [SerializeField] private Image tesciowaImage;
    public List<ItemSprite> itemsSprites;


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
                pannaImage.sprite = itemsSprites.Find(p => p.ID == id).Sprite;
                break;
            case PlayerType.Tesciowa:
                tesciowaImage.sprite = itemsSprites.Find(p => p.ID == id).Sprite;
                break;
        }
    }
}

[Serializable]
public struct ItemSprite
{
    public ItemID ID;
    public Sprite Sprite;
}
