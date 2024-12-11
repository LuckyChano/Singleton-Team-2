using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject CannonTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject MagicTurretPrefab;

    private TurretBlueprint turretToBuild;

    private PlayerStats playerStats;
    private TurretManager turretManager;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        // Inicializar referencias a PlayerStats y TurretManager
        playerStats = FindObjectOfType<PlayerStats>();
        turretManager = FindObjectOfType<TurretManager>();

        if (playerStats == null || turretManager == null)
        {
            Debug.LogError("PlayerStats o TurretManager no encontrados en la escena.");
        }
    }

    public bool CanBuild => turretToBuild != null;
    public bool HasMoney => playerStats != null && turretToBuild != null && playerStats.Money >= turretToBuild.cost;

    public void BuildTurretOn(Node node)
    {
        if (!CanBuild)
        {
            Debug.Log("No turret selected to build.");
            return;
        }

        if (!HasMoney)
        {
            Debug.Log("Not enough money to build.");
            return;
        }

        playerStats.ReduceMoney(turretToBuild.cost);

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.SetTurret(turret);

        Debug.Log($"Turret built! Money left: {playerStats.Money}");
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        Debug.Log($"Selected turret: {turret.prefab.name}");
    }
}