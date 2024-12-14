using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditionsManager : MonoBehaviour
{
    private List<IGameCondition> _conditions;
    private PlayerStats _playerStats;
    private WaveSpawner _waveSpawner;

    public void Initialize(List<IGameCondition> conditions, PlayerStats playerStats, WaveSpawner waveSpawner)
    {
        _conditions = conditions;
        _playerStats = playerStats;
        _waveSpawner = waveSpawner;
    }

    public PlayerStats GetPlayerStats() => _playerStats;

    public WaveSpawner GetWaveSpawner() => _waveSpawner;

    private void Update()
    {
        foreach (var condition in _conditions)
        {
            if (condition.IsConditionMet(this))
            {
                condition.Execute();
                break;
            }
        }
    }
}

public interface IGameCondition
{
    bool IsConditionMet(GameConditionsManager context);
    void Execute();
}
