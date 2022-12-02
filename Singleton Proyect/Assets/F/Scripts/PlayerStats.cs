using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Esta clase se encarga de los stats del player(DINERO Y VIDAS) y de regular la pantalla de victoria/derrota.//////////////////////////////////////////////////////////////////////
    public static PlayerStats instance;

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    private bool gameEnded = false;

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
    }

    void Update()
    {
        if (gameEnded)
            return;
    }

    void Start()
    { 
        Money = startMoney; 
        Lives = startLives;
    }

    public void ReduceLife()
    {
        if (PlayerStats.Lives > 0)
        {
            PlayerStats.Lives--;
        }
        else
        {
            PlayerStats.Lives = 0;
        }
    }
}
