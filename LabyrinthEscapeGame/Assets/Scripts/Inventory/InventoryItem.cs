using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newInventoryItem", menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
}
