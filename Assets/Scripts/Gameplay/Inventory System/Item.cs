using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoInteract
{
    public ItemData itemData;

    public override void Interact()
    {
        InventoryManager.Instance.AddItemToInventory(itemData);
        InteractManager.Instance.Interactable = null;
        InteractManager.Instance.OnHighlightEnd?.Invoke();
        Destroy(gameObject);
    }

    public override string GetText()
    {
        return itemData.ItemName;
    }

    public override void OnHighlight()
    {
        if (_highlighted) { return; }
        base.OnHighlight();

        transform.localScale *= 1.1f;
    }

    public override void OnHighlightEnd()
    {
        base.OnHighlightEnd();
        transform.localScale /= 1.1f;
    }
}
