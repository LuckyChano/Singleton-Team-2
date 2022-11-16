using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;    
    }
    public void BuyMagicTurret()
    {
        Debug.Log("MagicTurret");
        buildManager.SetTurretToBuild(buildManager.MagicTurretPrefab);
    }
    public void BuyCannonTurret()
    {
        Debug.Log("CannonTurret");
        buildManager.SetTurretToBuild(buildManager.CannonTurretPrefab);
    }
    public void BuyArrowTurret()
    {
        Debug.Log("ArrowTurret");
        buildManager.SetTurretToBuild(buildManager.ArrowTurretPrefab);
    }

    //NOTA: LA TORRETA MAGICA SE COLOCA Y DESPUES SE PUEDE MEJORAR EN ALGUN ELEMENTO.       
    //public void BuyMagicTurret()
    //{
    //    Debug.Log("MagicTurret");
    //}
}
