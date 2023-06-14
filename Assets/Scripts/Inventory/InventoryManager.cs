using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void UseItem(ItemData data)
    {
        player.AddAttributes(data.attributes);
        if (data.type == ItemType.Equipabble)
        {
            equipmentSlots[GetEquipmentSlot(data.slotType)].SetItem(data);
        }

        // TODO
        // If the item is a consumable, simply add the attributes of the item to the player.
        // If it is equippable, get the equipment slot that matches the item's slot.
        // Set the equipment slot's item as that of the used item
    }
    
    public void AddItem(string itemID)
    {
        for (int range = 0; range < itemDatabase.Count; range++)
        {
            if (itemID == itemDatabase[range].id)
            {
                Debug.Log(range+" "+GetEmptyInventorySlot());
                inventorySlots[GetEmptyInventorySlot()].SetItem(itemDatabase[range]);
                break;
            }
        }
        //TODO
        //1. Cycle through every item in the database until you find the item with the same id.
        //2. Get the index of the InventorySlot that does not have any Item and set its Item to the Item found
    }

    public int GetEmptyInventorySlot()
    {
       int range;
       for (range = 0; range < inventorySlots.Count; range++)
        {
            if (!inventorySlots[range].HasItem())
            {
                break;
            }
            else
            {
                continue;
            }
        }

        return range;
        //TODO
        //Check which inventory slot doesn't have an Item and return its index
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        int range = 0;
        if (type == EquipmentSlotType.Head)
        {
            range = 0;
        }
        else if (type == EquipmentSlotType.Chest)
        {
            range = 1;
        }
        else if (type == EquipmentSlotType.Legs)
        {
            range = 2;
        }
        else if (type == EquipmentSlotType.MainHand)
        {
            range = 3;
        }
        else if (type == EquipmentSlotType.SecondaryHand)
        {
            range = 4;
        }

        return range;
        //TODO
        //Check which equipment slot matches the slot type and return its index
    }

    public bool HasKey()
    {
        bool checker = false;
        for (int range = 0; range < inventorySlots.Count; range++)
        {
            if (inventorySlots[range].HasItem())
            {
                if (inventorySlots[range].itemData.type == ItemType.Key)
                {
                    checker = true;
                    break;
                }
            }
            else
            {
                continue;
            }
        }
        return checker;
    }

    public void UseKey()
    {
        for (int range = 0; range < inventorySlots.Count; range++)
        {
            if (inventorySlots[range].HasItem())
            {
                if (inventorySlots[range].itemData.type == ItemType.Key)
                {
                    inventorySlots[range].itemIcon.sprite = null;
                    inventorySlots[range].itemIcon.enabled = false;
                    inventorySlots[range].itemData = null;
                    break;
                }
            }
        }
    }
}
