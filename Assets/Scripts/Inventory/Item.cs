using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        if (Input.GetKey("e"))
        {
            if (id != "Door")
            {
                InventoryManager.Instance.AddItem(id);
                Destroy(gameObject);
            }
            else if (id == "Door")
            {
                if (InventoryManager.Instance.HasKey())
                {
                    gameObject.SetActive(false);
                    InventoryManager.Instance.UseKey();
                }
            }
        }
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
    }
}
