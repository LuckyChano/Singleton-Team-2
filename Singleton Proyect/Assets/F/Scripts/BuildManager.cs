using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        turretToBuild = standardTurretPrefab;    
    }
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
