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
    [SerializeField] TextMeshProUGUI AmountBuy = null;

    ItemStore myItem;

    public void SetButton(ItemStore item)
    {
        myItem = item;

        nameText.text = item.itemName;
        icon.sprite = item.img;
        costText.text = item.cost.ToString() + "$";
        AmountBuy.text = item.amountBuy.ToString();
    }

    public void BuyItem()
    {
        if (GameManager.instance.currencyCoins >= myItem.cost)
        {
            if (ItemId.Cash == myItem.type)
            {
                GameManager.instance.startMoney += myItem.amountBuy;
            }
            else if (ItemId.Heal == myItem.type)
            {
                GameManager.instance.startLives += myItem.amountBuy;
            }
            GameManager.instance.currencyCoins -= myItem.cost;
            GameManager.instance.SaveGame();
        }
    }
}