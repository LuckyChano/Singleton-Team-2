using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour, IScreen
{
    [SerializeField] private TextMeshProUGUI staminaCount = null;
    [SerializeField] private TextMeshProUGUI timer = null;
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI coinNumber = null;

    private void Start()
    {
        ScreenManager screenManager = FindObjectOfType<ScreenManager>();
        if (screenManager != null)
        {
            screenManager.RegisterScreen(ScreensType.mainMenuScreen, this);
        }
        else
        {
            Debug.LogError("No se encontró un ScreenManager en la escena.");
        }

        UpdateUI();
    }

    private void Update()
    {
        TextCoins();
        TextTimer();
    }

    public void BTN_Return()
    {
        AudioManager.instance.Play("Button");
        Hide();
        Application.Quit();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        TextStamina();
        TextTimer();
        TextCoins();
    }

    public void TextStamina()
    {
        if (staminaCount != null && GameManager.instance != null)
        {
            staminaCount.text = $"{GameManager.instance.stamina} / {GameManager.instance.maxStamina}";
        }
        else
        {
            Debug.LogError("Falta asignar staminaCount o GameManager no está disponible.");
        }
    }

    public void TextTimer()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("GameManager no está disponible.");
            return;
        }

        if (GameManager.instance.stamina >= GameManager.instance.maxStamina)
        {
            timer.text = "";
            timerText.text = "Estamina Llena";
            return;
        }

        timerText.text = "Tiempo:";
        TimeSpan timerValue = GameManager.instance.nextStaminaTime - DateTime.Now;

        if (timerValue.TotalSeconds <= 0)
        {
            GameManager.instance.stamina++;
            GameManager.instance.nextStaminaTime = DateTime.Now.AddSeconds(GameManager.instance.timeToRecharge);

            if (GameManager.instance.stamina >= GameManager.instance.maxStamina)
            {
                timer.text = "";
                timerText.text = "Estamina Llena";
                return;
            }
        }

        timer.text = $"{Mathf.FloorToInt((float)timerValue.TotalMinutes)}:{timerValue.Seconds:D2}";
    }

    public void TextCoins()
    {
        if (coinNumber != null && CurrencyManager.instance != null)
        {
            coinNumber.text = CurrencyManager.instance.currencyCoins.ToString();
        }
        else
        {
            Debug.LogError("Falta asignar coinNumber o CurrencyManager no está disponible.");
        }
    }

    public void SaveData()
    {
        GameManager.instance?.SaveGame();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        if (CurrencyManager.instance != null)
        {
            CurrencyManager.instance.currencyCoins = PlayerPrefs.GetInt("Currency");
        }
        else
        {
            Debug.LogError("CurrencyManager no está disponible.");
        }
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
