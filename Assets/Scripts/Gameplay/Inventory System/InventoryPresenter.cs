using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPresenter : MonoSingleton<InventoryPresenter>
{
    public List<InventorySlot> slots;
    private Transform _inventory;

    private void OnEnable()
    {
        InventoryManager.Instance.OnItemAdded += UpdateInventoryView;
    }
    private void OnDisable()
    {
        if(InventoryManager.Instance)
            InventoryManager.Instance.OnItemAdded -= UpdateInventoryView;
    }
    public void Awake()
    {
        _inventory = slots[0].transform.parent;
        UpdateInventoryView();
        print("InventoryPresenterAwake");
    }

    public void UpdateInventoryView()
    {
        print("UpdateInventoryView");
        ClearSlots();

        var items = InventoryManager.Instance.inventory;
        if(items.Count == 0 ) 
        {
            //CloseBar
            _inventory.DOMoveY(-86f, 1f);
        }
        else
        {
            //OpenBar
            _inventory.DOMoveY(86f, 1f);

            foreach (var item in items)
            {
                var nextSlot = GetSlot();
                if (nextSlot != null)
                {
                    nextSlot.AttachedItem(item);
                }
            }
        }

        print("UpdateInventoryViewDonee");
    }

    public InventorySlot GetSlot()
    {
        return slots.Find(slot => slot.IsEmpty);
    }

    public void ClearSlots()
    {
        foreach (var item in slots)
        {
            item.RemoveItem();
        }
    }
}
