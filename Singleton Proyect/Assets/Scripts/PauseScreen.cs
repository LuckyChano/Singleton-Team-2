using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour, IScreen
{
    private void Start()
    {
        gameObject.SetActive(false);
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
        Time.timeScale = 1f;
    }

    public void BTN_Continue()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Hide();
    }

    public void BTN_Return()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Hide();
    }

    public void BTN_Pause()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Show();
    }
    public void BTN_MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
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
