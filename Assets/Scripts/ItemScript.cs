using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction;
public class ItemScript : MonoBehaviour, IInteraction
{
    Item_SO ItemData;
    public void setItemData(ItemID id)
    {
        ItemData = GameManager.Instance.ItemsContainer.Get(id);
    }
    public Vector3 Position => transform.position;

    public ItemID Interact(ItemID id)
    {

        if (GameManager.Instance.ItemsContainer.Get(id).Type == NpcType.None)
        {
            return ItemData.id;
        }
        else return id;
    }

    public void Highlight()
    {
    }

    public void Unhighlight()
    {
    }
}
