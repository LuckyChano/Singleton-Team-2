using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currencyCoins;
    public bool gameEnded = false;
    public DateTime nextStaminaTime;
    public DateTime lastStaminaTime;
    public float timeToRecharge = 10f;
    public int maxStamina = 5;
    public int stamina;
    public bool puedoJugar;

    public int Money;
    public int startMoney = 400;
    public int Lives;
    public int startLives = 20;

    public GameObject CannonTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject MagicTurretPrefab;

    private TurretBlueprint _turretToBuild;
    
    //Propiedad que permite dicernir si la torreta se puede construir o no.
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return GameManager.instance.Money >= _turretToBuild.cost; } }

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

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        LoadGame();
    }

    void Update()
    {
        if (GameManager.instance.Lives <= 0)
        {
            CSceneManager.instance.EndGame();
        }

        HavePlay();
    }

    public void ReduceLife()
    {
        if (GameManager.instance.Lives > 0)
        {
            GameManager.instance.Lives--;
        }
        else
        {
            GameManager.instance.Lives = 0;
        }
    }

    //Construlle la torreta en el Nodo indicado si tenes el dinero suficiente./////////////////////////////////////////////////////////////////////////////////
    public void BuildTurretOn(Node node)
    {
        if (GameManager.instance.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enaugh money");
            return;
        }

        GameManager.instance.Money -= _turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build... Money left:" + GameManager.instance.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }

    public void HavePlay()
    {
        if (stamina > 0)
        {
            puedoJugar = true;
        }
        else
        {
            puedoJugar = false;
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Currency", currencyCoins);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Currency")) currencyCoins = PlayerPrefs.GetInt("Currency");
        //PlayerPrefs.DeleteKey("Life")
    }

    public void AddCoin()
    {
        if (currencyCoins <= 0)
        {
            currencyCoins++;
        }
    }

    public void RestCoin()
    {
        if (currencyCoins > 0)
        {
           currencyCoins--;
        }
    }
}
