using System;
using System.Collections;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    private bool restoring;

    public bool HaveStamina => GameManager.instance.stamina > 0;

    private int notifID;
    private MainMenuScreen menuScreen;

    private void Start()
    {
        menuScreen = FindObjectOfType<MainMenuScreen>();

        if (!PlayerPrefs.HasKey("currentStamina"))
        {
            PlayerPrefs.SetInt("currentStamina", GameManager.instance.maxStamina);
        }

        LoadTime();
        StartCoroutine(RestoreEnergy());

        if (GameManager.instance.stamina < GameManager.instance.maxStamina)
        {
            notifID = NotificationManager.instance.DisplayNotif(
                "Estamina Llena",
                "Estamina Recargada",
                AddDuration(DateTime.Now, ((GameManager.instance.maxStamina - GameManager.instance.stamina) * GameManager.instance.timeToRecharge) + 1f)
            );
        }
    }

    private void Update()
    {
        UpdateStaminaUI();
    }

    private IEnumerator RestoreEnergy()
    {
        restoring = true;

        while (GameManager.instance.stamina < GameManager.instance.maxStamina)
        {
            DateTime now = DateTime.Now;

            // Si el tiempo actual supera el tiempo de recarga, añade estamina.
            while (now >= GameManager.instance.nextStaminaTime && GameManager.instance.stamina < GameManager.instance.maxStamina)
            {
                GameManager.instance.stamina++;
                GameManager.instance.nextStaminaTime = AddDuration(GameManager.instance.nextStaminaTime, GameManager.instance.timeToRecharge);
                UpdateStaminaUI();
                SaveTime();
            }

            if (GameManager.instance.stamina >= GameManager.instance.maxStamina)
            {
                NotificationManager.instance.CancelNotif(notifID);
            }

            // Espera un segundo antes de verificar de nuevo.
            yield return new WaitForSeconds(1f);
        }

        restoring = false;
    }

    private DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    public void UseEnergy(int energyAmount)
    {
        if (GameManager.instance.stamina >= energyAmount)
        {
            GameManager.instance.stamina -= energyAmount;
            UpdateStaminaUI();
            SaveTime();

            // Reinicia el temporizador si no se está restaurando
            if (!restoring)
            {
                GameManager.instance.nextStaminaTime = AddDuration(DateTime.Now, GameManager.instance.timeToRecharge);
                StartCoroutine(RestoreEnergy());
            }
        }
    }

    private void UpdateStaminaUI()
    {
        menuScreen?.TextStamina();
        menuScreen?.TextTimer();
    }

    private void LoadTime()
    {
        GameManager.instance.stamina = PlayerPrefs.GetInt("currentStamina", GameManager.instance.maxStamina);
        GameManager.instance.nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime", DateTime.Now.ToString()));
    }

    private void SaveTime()
    {
        PlayerPrefs.SetInt("currentStamina", GameManager.instance.stamina);
        PlayerPrefs.SetString("nextStaminaTime", GameManager.instance.nextStaminaTime.ToString("o")); // Formato ISO 8601
    }

    private DateTime StringToDateTime(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime result))
        {
            return result;
        }
        return DateTime.Now;
    }
}