using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : Screens
{
    private void Start()
    {
        ScreenMG.instance.AddScreen(ScreensType.pauseScreen, this);
        Desactivate();
    }

    public void BTN_Continue()
    {
        AudioManager.instance.Play("Button");
        Desactivate();
        Time.timeScale = 1.0f;
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

    public void BTN_Pause()
    {
        AudioManager.instance.Play("Button");
        Activate();
        Time.timeScale = 0f;
    }
}
