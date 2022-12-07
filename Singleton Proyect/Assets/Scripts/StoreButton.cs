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

    public void SetButton(ItemStore item)
    {
        nameText.text = item.itemName;
        icon.sprite = item.img;
        costText.text = item.cost.ToString();
    }

    public void BuyItem()
    {

    }
}
