using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] Image icon = null;
    [SerializeField] TextMeshProUGUI costText = null;

    ItemStore myItem;

    public void SetButton(ItemStore item)
    {
        myItem = item;

        nameText.text = item.itemName;
        icon.sprite = item.img;
        costText.text = item.cost.ToString();
    }

    public void BuyItem()
    {
        if (GameManager.instance.currencyCoins > 0)
        {
           GameManager.instance.currencyCoins -= myItem.cost;
           GameManager.instance.SaveGame();
        }
    }
}
