using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int currencyCoins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Currency", currencyCoins);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Currency")) currencyCoins = PlayerPrefs.GetInt("Currency");
    }

    public void AddCoin()
    {
        currencyCoins++;
    }

    public void RestCoin()
    {
        if (currencyCoins > 0)
        {
            currencyCoins--;
        }
    }

    public void Reward()
    {
        CurrencyManager.instance.currencyCoins += 10;
    }
}
