using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float winCondition;

    public DateTime nextStaminaTime;
    public DateTime lastStaminaTime;
    public float timeToRecharge = 10f;
    public int maxStamina = 5;
    public int stamina;
    public bool puedoJugar;

    public float Money;
    public int startMoney;
    public int Lives;
    public int startLives;

    public int enemiesKill = 0;
    public int enemiesSpanw = 0;
    public int waveSurvive = 0;
    public bool survive = false;

    public GameObject CannonTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject MagicTurretPrefab;

    private TurretBlueprint _turretToBuild;

    //Propiedad que permite dicernir si la torreta se puede construir o no.
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return Money >= _turretToBuild.cost; } }

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
        if (Lives <= 0)
        {
            EventManager.Trigger(EventManager.NameEvent.Lose);
        }
        else if (Money > winCondition)
        {
            EventManager.Trigger(EventManager.NameEvent.Win);
        }

        HavePlay();
    }

    public void ReduceLife()
    {
        if (Lives > 0)
        {
            Lives--;
        }
        else
        {
            Lives = 0;
        }
    }

    //Construlle la torreta en el Nodo indicado si tenes el dinero suficiente./////////////////////////////////////////////////////////////////////////////////
    public void BuildTurretOn(Node node)
    {
        if (Money < _turretToBuild.cost)
        {
            Debug.Log("Not enaugh money");
            return;
        }

        Money -= _turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build... Money left:" + Money);
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
        PlayerPrefs.SetInt("Life", Lives);
        PlayerPrefs.SetFloat("Money", Money);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Life")) Lives = PlayerPrefs.GetInt("Life");
        if (PlayerPrefs.HasKey("Money")) Money = PlayerPrefs.GetFloat("Money");
    }
}
