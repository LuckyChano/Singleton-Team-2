using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //Este Script se encarga de Manejar los Nodos en los cuales podes construir las torretas./////////////////////////////////////////////////////////////////////


    public Vector3 positionOffset;

    public Color hoverColor;
    public Color cantBuyColor;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;
    
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void OnMouseDown()
    {
        //Evita que el UI blockee la interaccion con los nodos. ---- (ej: si estan abajo del UI)
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Instancia la torreta en el nodo si no hay una torreta ya en ese lugar.
        if (!gameManager.CanBuild)
            return;
        
        if (turret != null)
        {
            Debug.Log("You cant build Here");
            return;
        }

        gameManager.BuildTurretOn(this);
        
    }

    public void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!gameManager.CanBuild)
            return;

        if (gameManager.HasMoney)
        {
            rend.material.color = hoverColor;   
        }
        else
        {
            rend.material.color = cantBuyColor;
        }
    }

    public void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
