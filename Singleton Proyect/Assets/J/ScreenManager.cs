using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    [SerializeField] TextMeshProUGUI outStamina = null;

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
}
