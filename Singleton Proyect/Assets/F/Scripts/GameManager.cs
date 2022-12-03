using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gameEnded = false;
    private TurretBlueprint turretToBuild;

    public int stamina;
    public bool puedoJugar;

    public int Money;
    public int startMoney = 400;

    internal void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    public int Lives;
    public int startLives = 20;

    public GameObject CannonTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject MagicTurretPrefab;

    //Propiedad que permite dicernir si la torreta se puede construir o no.
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return GameManager.instance.Money >= turretToBuild.cost; } }

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

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    void Update()
    {
        if (GameManager.instance.Lives <= 0)
        {
            EndGame();
        }

        HavePlay();
    }

    //Construlle la torreta en el Nodo indicado si tenes el dinero suficiente./////////////////////////////////////////////////////////////////////////////////
    public void BuildTurretOn(Node node)
    {
        if (GameManager.instance.Money < turretToBuild.cost)
        {
            Debug.Log("Not enaugh money");
            return;
        }

        GameManager.instance.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build... Money left:" + GameManager.instance.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void EndGame()
    {
        //Agregar splash de derrota.// FALTA
        gameEnded = true;
        Debug.Log("GAME OVER");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl 1");
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
}
