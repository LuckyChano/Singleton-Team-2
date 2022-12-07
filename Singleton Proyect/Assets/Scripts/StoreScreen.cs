using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreScreen : Screens
{
    //[SerializeField] TextMeshProUGUI nameText = null;
    //[SerializeField] Image icon = null;
    //[SerializeField] TextMeshProUGUI costText = null;

    private void Start()
    {
        ScreenMG.instance.AddScreen(ScreensType.storeScreen, this);
        Desactivate();
    }

    public void BTN_Return()
    {
        Desactivate();
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
    }

    public override void Desactivate()
    {
        gameObject.SetActive(false);
        SetInteractionsButtons(false);
    }

    private void SetInteractionsButtons(bool active)
    {
        var b = GetComponentsInChildren<Button>();

        foreach (var item in b)
        {
            item.interactable = active;
        }
    }

    //public void SetButton(ItemStore item)
    //{
    //    nameText.text = item.itemName;
    //    icon.sprite = item.img;
    //    costText.text = item.cost.ToString();
    //}

    //public void BuyItem()
    //{

    //}
}
