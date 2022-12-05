using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour, IScreen
{

    //Implementar borones si es necesario

    [SerializeField] TextMeshProUGUI staminaCount = null;
    [SerializeField] TextMeshProUGUI timer = null;
    [SerializeField] TextMeshProUGUI timerText = null;

    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void Desactivate()
    {
        throw new System.NotImplementedException();
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

    private void SetInteractionsButtons(bool active)
    {
        var b = GetComponentsInChildren<Button>();

        foreach (var item in b)
        {
            item.interactable = active;
        }
    }
}
