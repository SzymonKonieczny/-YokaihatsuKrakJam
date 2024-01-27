using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsContainer", menuName = "ScriptableObjects/ItemsContainer")]
public class ItemsContainer : ScriptableObject
{
    [SerializeField] private List<Item_SO> _items;

    public Item_SO Get(ItemID id)
    {
        return _items.Find(p => p.id == id);
    }
}
