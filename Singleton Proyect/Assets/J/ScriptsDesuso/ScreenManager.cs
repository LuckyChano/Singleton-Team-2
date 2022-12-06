using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI staminaCount = null;
    [SerializeField] TextMeshProUGUI timer = null;
    [SerializeField] TextMeshProUGUI timerText = null;

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
        StaminaState(); //esto va en gm
    }

    //Esto va en gm
    public void StaminaState()
    {
        if (GameManager.instance.puedoJugar)
        {
            staminaText.gameObject.SetActive(false);
        }
        else
        {
            staminaText.gameObject.SetActive(true);
        }
    }

    public void TextStamina()
    {
        staminaCount.text = GameManager.instance.stamina.ToString() + " / " + GameManager.instance.maxStamina.ToString();
    }

    public void TextTimer()
    {
        if (GameManager.instance.stamina >= GameManager.instance.maxStamina)
        {
            this.timer.text = "";
            timerText.text = "Estamina Llena";
            return;
        }

        timerText.text = "Tiempo:";
        TimeSpan timer = GameManager.instance.nextStaminaTime - DateTime.Now;

        this.timer.text = timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
    }
}
