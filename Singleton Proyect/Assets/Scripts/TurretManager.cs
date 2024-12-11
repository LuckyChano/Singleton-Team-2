using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private TurretBlueprint _selectedTurret;

    public void SelectTurret(TurretBlueprint turret) => _selectedTurret = turret;

    public bool CanBuild(PlayerStats playerStats) =>
        _selectedTurret != null && playerStats.Money >= _selectedTurret.cost;

    public void BuildTurret(Node node, PlayerStats playerStats)
    {
        if (CanBuild(playerStats))
        {
            playerStats.ReduceMoney(_selectedTurret.cost);
            Instantiate(_selectedTurret.prefab, node.GetBuildPosition(), Quaternion.identity);
        }
    }
}
