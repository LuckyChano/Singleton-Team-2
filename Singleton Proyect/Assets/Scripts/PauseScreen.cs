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
        gameObject.SetActive(false); // Asegura que la pantalla esté desactivada al inicio.
    }

    public void Show()
    {
        gameObject.SetActive(true);
        SetInteractionsButtons(true);
        Time.timeScale = 0f; // Pausa el tiempo cuando la pantalla está activa.
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        SetInteractionsButtons(false);
        Time.timeScale = 1f; // Reanuda el tiempo cuando la pantalla se cierra.
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

    private void SetInteractionsButtons(bool active)
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.interactable = active;
        }
    }
}
