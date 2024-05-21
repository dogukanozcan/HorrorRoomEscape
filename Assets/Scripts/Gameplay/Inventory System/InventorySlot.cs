using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool IsEmpty { get => attachedItem == null; }

    [SerializeField] private TextMeshProUGUI nameLabel;
    private ItemData attachedItem;
    [SerializeField] private Image image;
  
    public void SelectSlot()
    {
        transform.localScale = Vector3.one*1.1f;
    }
    public void DeselectSlot()
    {
        transform.localScale = Vector3.one;
    }
    public void AttachedItem(ItemData item) 
    {
        attachedItem = item;
        SetImage(item);
        UpdateName();
    }

    public void RemoveItem()
    {
        attachedItem = null;
        RemoveImage();
        UpdateName();
    }

    public void SetImage(ItemData item)
    {
        image.sprite = item.itemSprite;
        image.color = Color.white;
    }
    public void RemoveImage()
    {
        image.sprite = null;
        image.color = Color.clear;
    }

    public void UpdateName()
    {
        if(attachedItem != null)
        {
            nameLabel.text = attachedItem.ItemName;
        }
        else
        {
            nameLabel.text = "";
        }
    }
}
