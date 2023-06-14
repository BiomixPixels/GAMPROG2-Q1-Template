using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData itemData;
    public Image itemIcon;

    private void Start()
    {
        itemData = null;
    }

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        itemData = data;
        itemIcon.enabled = true;
        itemIcon.sprite = data.icon; 
    }

    public void UseItem()
    {
        if (itemData.type != ItemType.Key)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemData = null;
        }
        // TODO
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }

    public string dataContent()
    {
        return itemData.id;
    }
}
