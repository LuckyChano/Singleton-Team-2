using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild; // Almacena la torreta seleccionada.
    private PlayerStats playerStats;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Más de un BuildManager en la escena.");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats no encontrado en la escena.");
        }
    }

    public bool CanBuild => turretToBuild != null;
    public bool HasMoney => playerStats != null && turretToBuild != null && playerStats.Money >= turretToBuild.cost;

    public void BuildTurretOn(Node node)
    {
        if (!CanBuild)
        {
            Debug.Log("No hay torreta seleccionada.");
            return;
        }

        if (!HasMoney)
        {
            Debug.Log("No hay suficiente dinero.");
            return;
        }

        // Reduce el dinero del jugador.
        playerStats.ReduceMoney(turretToBuild.cost);

        // Construye la torreta en el nodo.
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.SetTurret(turret); // Registra la torreta en el nodo.

        Debug.Log($"Torreta construida. Dinero restante: {playerStats.Money}");
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        Debug.Log($"Torreta seleccionada: {turret.prefab.name}");
    }
}
