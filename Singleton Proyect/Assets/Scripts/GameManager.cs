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

        if (PlayerStats == null)
            Debug.LogError("PlayerStats no está asignado al GameManager.");
        if (TurretManager == null)
            Debug.LogError("TurretManager no está asignado al GameManager.");
        if (GameConditionsManager == null)
            Debug.LogError("GameConditionsManager no está asignado al GameManager.");
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
        LoadLevelProgress();

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

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Life") && PlayerPrefs.HasKey("Money"))
        {
            if (PlayerStats != null)
            {
                PlayerStats.Initialize(
                    PlayerPrefs.GetInt("Money"),
                    PlayerPrefs.GetInt("Life")
                );
            }
            else
            {
                Debug.LogWarning("No se pudo inicializar PlayerStats durante la carga del juego.");
            }
        }

        if (PlayerPrefs.HasKey("nextStaminaTime"))
        {
            long temp;
            if (long.TryParse(PlayerPrefs.GetString("nextStaminaTime"), out temp))
            {
                nextStaminaTime = DateTime.FromBinary(temp);
            }
            else
            {
                Debug.LogWarning("El valor de nextStaminaTime en PlayerPrefs no es un número válido.");
                nextStaminaTime = DateTime.Now.AddSeconds(timeToRecharge);
            }
        }
        else
        {
            nextStaminaTime = DateTime.Now.AddSeconds(timeToRecharge);
        }

        stamina = PlayerPrefs.GetInt("Stamina", maxStamina);
    }

    public void SaveLevelProgress(int currentLevel)
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    public void LoadLevelProgress()
    {
        int savedLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    public void HavePlay()
    {
        puedoJugar = stamina > 0;
    }
}
