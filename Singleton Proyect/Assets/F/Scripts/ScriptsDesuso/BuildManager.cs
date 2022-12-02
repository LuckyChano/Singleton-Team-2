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

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager");
            return;
        }
        instance = this;
    }

    //Propiedad que permite dicernir si la torreta se puede construir o no.
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return GameManager.instance.Money >= turretToBuild.cost; } }




    //Construlle la torreta en el Nodo indicado si tenes el dinero suficiente./////////////////////////////////////////////////////////////////////////////////
    public void BuildTurretOn(Node node)
    {
        if(GameManager.instance.Money < turretToBuild.cost)
        {
            Debug.Log("Not enaugh money");
            return;
        }

        GameManager.instance.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build... Money left:" + GameManager.instance.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
