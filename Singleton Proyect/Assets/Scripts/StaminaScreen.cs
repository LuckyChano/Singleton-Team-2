using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScreen : MonoBehaviour, IScreen
{
    private void Start()
    {
        var screenManager = FindObjectOfType<ScreenManager>();
        if (screenManager != null)
        {
            screenManager.RegisterScreen(ScreensType.staminaScreen, this);
            Hide();
        }
        else
        {
            Debug.LogError("ScreenManager no encontrado en la escena.");
        }
    }

    public void BTN_Return()
    {
        AudioManager.instance.Play("Button");
        Hide();
    }

    public void CantPlay()
    {
        if (!GameManager.instance.puedoJugar)
        {
            Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
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