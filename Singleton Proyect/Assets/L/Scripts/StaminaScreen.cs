using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScreen : MonoBehaviour, IScreen
{

    //Chequeamos stamina y depende de si hay o no mostarmos el cartel.

    public void BTN_Return()
    {
        ScreenMG.instance.Pop();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
    }

    public void Desactivate()
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
}
