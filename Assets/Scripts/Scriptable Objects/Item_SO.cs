using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item_Data")]

public class Item_SO : ScriptableObject
{
    public ItemID id;
    
    NpcType Type;

}
