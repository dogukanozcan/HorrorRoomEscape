using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    public List<ItemData> inventory = new List<ItemData>();
    public event Action OnItemAdded;
    public void AddItemToInventory(ItemData item)
    {
        inventory.Add(item); 
        OnItemAdded?.Invoke();
    }
}
