using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemData : ScriptableObject
{
    [ShowInInspector] public string ItemName => name;
    [ShowInInspector] public int ItemID => base.GetHashCode();

    public Sprite itemSprite;
}
