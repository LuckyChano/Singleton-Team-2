using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour, IScreen
{
    private void Start()
    {
        var screenManager = FindObjectOfType<ScreenManager>();
        if (screenManager != null)
        {
            screenManager.RegisterScreen(ScreensType.infoScreen, this);
        }
        else
        {
            Debug.LogError("ScreenManager no encontrado en la escena.");
        }

        Show();
    }

    public void BTN_Continue()
    {
        AudioManager.instance.Play("Button");
        Hide();
        Time.timeScale = 1.0f;
    }

    public void BTN_Return()
    {
        AudioManager.instance.Play("Button");
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        SetInteractionsButtons(false);
    }

    private void SetInteractionsButtons(bool active)
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.interactable = active;
        }
    }
}