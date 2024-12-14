using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour, IScreen
{
    private void Start()
    {
        var screenManager = FindObjectOfType<ScreenManager>();
        if (screenManager != null)
        {
            screenManager.RegisterScreen(ScreensType.winScreen, this);
            Hide();
        }
        else
        {
            Debug.LogError("ScreenManager no encontrado en la escena.");
        }
    }

    public void BTN_NextLevel()
    {
        AudioManager.instance.Play("Button");
        CSceneManager.instance.NextLevel();
    }

    public void BTN_Return()
    {
        AudioManager.instance.Play("Button");
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        AudioManager.instance.Play("Win");
        SetInteractionsButtons(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        SetInteractionsButtons(false);
    }
    public void BTN_MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        AudioManager.instance.Play("Button");
        FindObjectOfType<CSceneManager>().MainMenu();
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