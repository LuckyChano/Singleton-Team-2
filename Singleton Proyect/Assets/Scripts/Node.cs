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

    private Turret _turret;
    private TurretBlueprint _turretBlueprint;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    public Vector3 GetBuildPosition() => transform.position + positionOffset;

    private void OnMouseDown()
    {
        var turretManager = FindObjectOfType<TurretManager>();
        var playerStats = FindObjectOfType<PlayerStats>();

        if (!turretManager.CanBuild(playerStats)) return;
        if (_turret != null) return;

        turretManager.BuildTurret(this, playerStats);
    }

    private void OnMouseEnter()
    {
        var turretManager = FindObjectOfType<TurretManager>();
        var playerStats = FindObjectOfType<PlayerStats>();

        _renderer.material.color = turretManager.CanBuild(playerStats) ? hoverColor : cantBuyColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
    public void SetTurret(GameObject newTurret)
    {
        _turretBlueprint.prefab = newTurret;
    }
}
