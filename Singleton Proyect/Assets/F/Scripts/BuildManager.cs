using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Este script se encarga de Instanciar las diferentes torretas en el nodo.////////////////////////////////////////////////////////////////////////////////////

    public static BuildManager instance;

    public GameObject CannonTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject MagicTurretPrefab;

    private TurretBlueprint turretToBuild;

    //Propiedad que permite dicernir si la torreta se puede construir o no.
    public bool CanBuild { get { return turretToBuild != null; } }

    //Construlle la torreta en el Nodo indicado si tenes el dinero suficiente./////////////////////////////////////////////////////////////////////////////////
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.Cost)
        {
            Debug.Log("Not enaugh money");
            return;
        }

        PlayerStats.Money -= turretToBuild.Cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build... Money left:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
