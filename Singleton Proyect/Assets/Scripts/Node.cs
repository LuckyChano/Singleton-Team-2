using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    public Color hoverColor;
    public Color cantBuyColor;

    private Renderer _renderer;
    private Color _startColor;

    private GameObject _turret;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    public Vector3 GetBuildPosition() => transform.position + positionOffset;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        var buildManager = BuildManager.instance;

        if (!buildManager.CanBuild) return;
        if (_turret != null)
        {
            Debug.Log("Nodo ocupado.");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        var buildManager = BuildManager.instance;

        if (!buildManager.CanBuild)
        {
            _renderer.material.color = cantBuyColor;
        }
        else
        {
            _renderer.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }

    public void SetTurret(GameObject turret)
    {
        _turret = turret;
    }
}