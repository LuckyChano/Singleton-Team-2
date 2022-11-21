using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //Este script se encarga de seleccionar la torreta que voy a construir una vez que el BluePrint fue seleccionado./////////////////////////////////////////////////////////////////////////////////////

    public TurretBlueprint arrowTurret;
    public TurretBlueprint cannonTurret;
    public TurretBlueprint magicTurret;

    BuildManager buildManager; 

    void Start()
    {
        buildManager = BuildManager.instance;    
    }

    //Estos llaman a un metodo en el build manager que se encargar de seleccionar la torreta que se va a construir.
    public void SelectArrowTurret()
    {
        Debug.Log("ArrowTurret");
        buildManager.SelectTurretToBuild(arrowTurret);
    }
    public void SelectCannonTurret()
    {
        Debug.Log("CannonTurret");
        buildManager.SelectTurretToBuild(cannonTurret);
    }
    public void SelectMagicTurret()
    {
        Debug.Log("MagicTurret");
        buildManager.SelectTurretToBuild(magicTurret);
    }

    //NOTA: LA TORRETA MAGICA SE COLOCA Y DESPUES SE PUEDE MEJORAR EN ALGUN ELEMENTO.
}
