using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    [SerializeField] TextMeshProUGUI outStamina = null;
    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] TextMeshProUGUI fullTimeText = null;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        StaminaState();
    }

    public void StaminaState()
    {
        if (GameManager.instance.puedoJugar)
        {
            outStamina.gameObject.SetActive(false);
        }
        else
        {
            outStamina.gameObject.SetActive(true);
        }
    }

    public void TextStamina()
    {
        staminaText.text = GameManager.instance.stamina.ToString() + " / " + GameManager.instance.maxStamina.ToString();
    }

    public void TextTimer()
    {
        if (GameManager.instance.stamina >= GameManager.instance.maxStamina)
        {
            timerText.text = "";
            fullTimeText.text = "Estamina Llena";
            return;
        }

        fullTimeText.text = "Tiempo:";
        TimeSpan timer = GameManager.instance.nextStaminaTime - DateTime.Now;

        timerText.text = timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
    }
}
