using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction;
public class ItemScript : MonoBehaviour, IInteraction
{
    [SerializeField] SpriteRenderer sprite;
    Item_SO ItemData;
    private void Start()
    {
        Destroy(this.gameObject, 20f);
    }
    public void setItemData(ItemID id)
    {
        ItemData = GameManager.Instance.ItemsContainer.Get(id); //zaciaga jakims hujem nulla ;-;
        sprite.sprite = ItemData.sprite;
        sprite.color = ItemData.color;
    }
    public Vector3 Position => transform.position;

    public ItemID Interact(ItemID id)
    {

        if (GameManager.Instance.ItemsContainer.Get(id).Type == NpcType.None)
        {
            Destroy(gameObject);
            return ItemData.id;
        }
        else
        {
            return id;
        }
    }

    public void Highlight()
    {
    }

    public void Unhighlight()
    {
    }
}
