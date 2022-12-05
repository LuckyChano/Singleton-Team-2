using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaminaSystem : MonoBehaviour
{
    bool restoring;

    public bool HaveStamina { get => GameManager.instance.stamina > 0; }

    int notifID;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("currentStamina"))
            PlayerPrefs.SetInt("currentStamina", GameManager.instance.maxStamina);

        LoadTime();
        StartCoroutine(RestoreEnergy());

        if (GameManager.instance.stamina < GameManager.instance.maxStamina)
        {
            notifID = NotificationManager.instance.DisplayNotif("Estamina LLena", "Estamina Recargada",
                AddDuration(DateTime.Now, ((GameManager.instance.maxStamina - GameManager.instance.stamina) * GameManager.instance.timeToRecharge) + 1f));
        }
    }


    IEnumerator RestoreEnergy()
    {
        UpdateStamina();
        restoring = true;
        while (GameManager.instance.stamina < GameManager.instance.maxStamina)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = GameManager.instance.nextStaminaTime;
            bool staminaAdd = false;

            while (currentDateTime > nextDateTime)
            {
                if (GameManager.instance.stamina < GameManager.instance.maxStamina)
                {
                    GameManager.instance.stamina += 1;
                    staminaAdd = true;
                    UpdateStamina();
                    DateTime timeToAdd = DateTime.Now;
                    if (GameManager.instance.lastStaminaTime > nextDateTime)
                        timeToAdd = GameManager.instance.lastStaminaTime;
                    else
                        timeToAdd = nextDateTime;

                    nextDateTime = AddDuration(timeToAdd, GameManager.instance.timeToRecharge);
                }
                else
                {
                    break;
                }
            }

            if (staminaAdd)
            {
                GameManager.instance.lastStaminaTime = DateTime.Now;
                GameManager.instance.nextStaminaTime = nextDateTime;
            }

            UpdateTimer();
            UpdateStamina();
            SaveTime();
            yield return new WaitForEndOfFrame();
        }
        NotificationManager.instance.CancelNotif(notifID);
        restoring = false;
    }

    DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    public void UseEnergy(int energyAmmount)
    {
        if (GameManager.instance.stamina - energyAmmount >= 0)
        {
            GameManager.instance.stamina -= energyAmmount;
            UpdateStamina();

            NotificationManager.instance.CancelNotif(notifID);
            notifID = NotificationManager.instance.DisplayNotif("Estamina Llena", "Estamina Recargada",
                AddDuration(DateTime.Now, ((GameManager.instance.maxStamina - GameManager.instance.stamina) * GameManager.instance.timeToRecharge) + 1f));

            if (!restoring)
            {
                GameManager.instance.nextStaminaTime = AddDuration(DateTime.Now, GameManager.instance.timeToRecharge);
                StartCoroutine(RestoreEnergy());
            }
        }
    }

    void UpdateStamina()
    {
        ScreenManager.instance.TextStamina();
    }

    void UpdateTimer()
    {
        ScreenManager.instance.TextTimer();
    }

    void LoadTime()
    {
        GameManager.instance.stamina = PlayerPrefs.GetInt("currentStamina");
        GameManager.instance.nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        GameManager.instance.lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    void SaveTime()
    {
        PlayerPrefs.SetInt("currentStamina", GameManager.instance.stamina);
        PlayerPrefs.SetString("nextStaminaTime", GameManager.instance.nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", GameManager.instance.lastStaminaTime.ToString());
    }

    DateTime StringToDateTime(string timeString)
    {
        if (string.IsNullOrEmpty(timeString))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(timeString);
        }
    }
}
