using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Player player;
    private ItemData itemData;

    public void SetItem(ItemData data)
    {
        if (itemData != null)
        {
            Unequip();
        }
        defaultIcon.gameObject.SetActive(false);
        itemIcon.gameObject.SetActive(true);
        itemData = data;
        itemIcon.sprite = data.icon;
        // TODO
        // Set the item data the and icons here
        // Make sure to apply the attributes once an item is equipped
    }

    public void Unequip()
    {
        if (InventoryManager.Instance.GetEmptyInventorySlot() <= InventoryManager.Instance.inventorySlots.Count)
        { 
            InventoryManager.Instance.AddItem(itemData.id);
            player.RemoveAttributes(itemData.attributes);
            itemIcon.gameObject.SetActive(false);
            defaultIcon.gameObject.SetActive(true);
            itemData = null;
        }

        // TODO
        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
    }
}
