using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScreen : MonoBehaviour, IScreen
{
    public void BTN_Return()
    {
        Desactivate();
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
