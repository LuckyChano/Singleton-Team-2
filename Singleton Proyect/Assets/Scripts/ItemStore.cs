using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "CustomScriptables/Item")]
public class ItemStore : ScriptableObject
{
    public string itemName;
    public int cost;
    public int amountBuy;
    public Sprite img;
    public ItemId type;
}
public enum ItemId { Heal, Cash }