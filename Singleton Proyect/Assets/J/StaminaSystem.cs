using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] int maxStamina = 5;
    [SerializeField] float timeToRecharge = 10f;
    bool restoring;

    public bool HaveStamina { get => MainMenu.instance.stamina > 0; }

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] TextMeshProUGUI fullTimeText = null;

    int notifID;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("currentStamina"))
            PlayerPrefs.SetInt("currentStamina", maxStamina);

        LoadTime();
        StartCoroutine(RestoreEnergy());

        if (MainMenu.instance.stamina < maxStamina)
        {
            notifID = NotificationManager.instance.DisplayNotif("Estamina LLena", "Estamina Recargada",
                AddDuration(DateTime.Now, ((maxStamina - MainMenu.instance.stamina) * timeToRecharge) + 1f));
        }
    }


    IEnumerator RestoreEnergy()
    {
        UpdateStamina();
        restoring = true;
        while (MainMenu.instance.stamina < maxStamina)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextStaminaTime;
            bool staminaAdd = false;

            while (currentDateTime > nextDateTime)
            {
                if (MainMenu.instance.stamina < maxStamina)
                {
                    MainMenu.instance.stamina += 1;
                    staminaAdd = true;
                    UpdateStamina();
                    DateTime timeToAdd = DateTime.Now;
                    if (lastStaminaTime > nextDateTime)
                        timeToAdd = lastStaminaTime;
                    else
                        timeToAdd = nextDateTime;

                    nextDateTime = AddDuration(timeToAdd, timeToRecharge);
                }
                else
                {
                    break;
                }
            }

            if (staminaAdd)
            {
                lastStaminaTime = DateTime.Now;
                nextStaminaTime = nextDateTime;
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
        if (MainMenu.instance.stamina - energyAmmount >= 0)
        {
            MainMenu.instance.stamina -= energyAmmount;
            UpdateStamina();

            NotificationManager.instance.CancelNotif(notifID);
            notifID = NotificationManager.instance.DisplayNotif("Estamina Llena", "Estamina Recargada",
                AddDuration(DateTime.Now, ((maxStamina - MainMenu.instance.stamina) * timeToRecharge) + 1f));

            if (!restoring)
            {
                nextStaminaTime = AddDuration(DateTime.Now, timeToRecharge);
                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            Debug.Log("Sin Estamina");
        }
    }

    void UpdateStamina()
    {
        staminaText.text = MainMenu.instance.stamina.ToString() + " / " + maxStamina.ToString();
    }

    void UpdateTimer()
    {
        if (MainMenu.instance.stamina >= maxStamina)
        {
            timerText.text = "";
            fullTimeText.text = "Estamina Llena";
            return;
        }

        fullTimeText.text = "Tiempo:";
        TimeSpan timer = nextStaminaTime - DateTime.Now;

        timerText.text = timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
    }

    void LoadTime()
    {
        MainMenu.instance.stamina = PlayerPrefs.GetInt("currentStamina");
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    void SaveTime()
    {
        PlayerPrefs.SetInt("currentStamina", MainMenu.instance.stamina);
        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", lastStaminaTime.ToString());
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
