using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    private Item item;

    public override void Interact()
    {
        if (Input.GetKey("e"))
        {
            //InventoryManager.Instance.AddItem(item.id);
            Destroy(gameObject);
        }
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
    }
}
