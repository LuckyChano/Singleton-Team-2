using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //Este Script se encarga de Manejar los Nodos en los cuales podes construir las torretas./////////////////////////////////////////////////////////////////////

    private Renderer rend;

    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        //Evita que el UI blockee la interaccion con los nodos. ---- (ej: si estan abajo del UI)
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Instancia la torreta en el nodo si no hay una torreta ya en ese lugar.
        if (!buildManager.CanBuild)
            return;
        
        if (turret != null)
        {
            Debug.Log("You cant build Here");
            return;
        }

        buildManager.BuildTurretOn(this);
        
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!buildManager.CanBuild)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
