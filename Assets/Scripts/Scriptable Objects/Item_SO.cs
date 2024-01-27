using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HappinessInfluence
{
    Positive,
    Negative
}
[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item_Data")]

public class Item_SO : ScriptableObject
{
    public ItemID id;
    public HappinessInfluence Infuence;
     public NpcType Type;
     public float InfluenceValue = 0.05f;
}
