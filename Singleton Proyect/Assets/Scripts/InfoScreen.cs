using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoScreen : Screens
{
    private void Start()
    {
        ScreenMG.instance.AddScreen(ScreensType.infoScreen, this);
    }

    public void BTN_Continue()
    {
        Desactivate();
        Time.timeScale = 1.0f;
    }

    public void BTN_Return()
    {
        Desactivate();
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
        Time.timeScale = 0f;
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
