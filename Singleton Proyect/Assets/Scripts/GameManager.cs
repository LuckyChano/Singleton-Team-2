using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public DateTime nextStaminaTime;
    public float timeToRecharge = 10f;
    public int maxStamina = 5;
    public int stamina;
    public bool puedoJugar;

    public int startMoney;
    public int startLives;

    public PlayerStats PlayerStats { get; private set; }
    public TurretManager TurretManager { get; private set; }
    public GameConditionsManager GameConditionsManager { get; private set; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        PlayerStats = GetComponent<PlayerStats>();
        TurretManager = GetComponent<TurretManager>();
        GameConditionsManager = GetComponent<GameConditionsManager>();
    }

    private void Start()
    {
        GameConditionsManager.Initialize(new List<IGameCondition>
        {
            new WinCondition(3000),
            new LoseCondition()
        });

        PlayerStats.Initialize(startMoney, startLives);
        LoadGame();

        if (nextStaminaTime == default(DateTime))
        {
            nextStaminaTime = DateTime.Now.AddSeconds(timeToRecharge);
        }
    }

    private void Update()
    {
        HavePlay();

        if (stamina < maxStamina && DateTime.Now >= nextStaminaTime)
        {
            stamina++;
            nextStaminaTime = DateTime.Now.AddSeconds(timeToRecharge);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Life", PlayerStats.Lives);
        PlayerPrefs.SetInt("Money", PlayerStats.Money);

        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToBinary().ToString());
        PlayerPrefs.SetInt("Stamina", stamina);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Life") && PlayerPrefs.HasKey("Money"))
        {
            PlayerStats.Initialize(
                PlayerPrefs.GetInt("Money"),
                PlayerPrefs.GetInt("Life")
            );
        }

        if (PlayerPrefs.HasKey("nextStaminaTime"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("nextStaminaTime"));
            nextStaminaTime = DateTime.FromBinary(temp);
        }
        else
        {
            nextStaminaTime = DateTime.Now.AddSeconds(timeToRecharge);
        }

        stamina = PlayerPrefs.GetInt("Stamina", maxStamina);
    }

    public void HavePlay()
    {
        puedoJugar = stamina > 0;
    }
}
