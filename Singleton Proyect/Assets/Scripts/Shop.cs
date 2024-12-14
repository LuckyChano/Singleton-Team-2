using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint arrowTurret;
    public TurretBlueprint cannonTurret;
    public TurretBlueprint magicTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArrowTurret()
    {
        Debug.Log("Seleccionando torreta de flechas.");
        buildManager.SelectTurretToBuild(arrowTurret);
    }

    public void SelectCannonTurret()
    {
        Debug.Log("Seleccionando torreta de cañón.");
        buildManager.SelectTurretToBuild(cannonTurret);
    }

    public void SelectMagicTurret()
    {
        Debug.Log("Seleccionando torreta mágica.");
        buildManager.SelectTurretToBuild(magicTurret);
    }
}