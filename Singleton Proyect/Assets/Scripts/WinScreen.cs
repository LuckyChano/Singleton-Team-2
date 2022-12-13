using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : Screens
{
    private void Start()
    {
        ScreenMG.instance.AddScreen(ScreensType.winScreen, this);
        Desactivate();
    }

    public void BTN_NextLevel()
    {
        AudioManager.instance.Play("Button");
        CSceneManager.instance.NextLevel();
    }

    public void BTN_Return()
    {
        AudioManager.instance.Play("Button");
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
