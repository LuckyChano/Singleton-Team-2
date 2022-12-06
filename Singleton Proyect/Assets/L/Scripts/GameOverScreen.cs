using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : Screens
{
    private void Start()
    {
        ScreenMG.instance.AddScreen(ScreensType.gameOverScreen, this);
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
}
