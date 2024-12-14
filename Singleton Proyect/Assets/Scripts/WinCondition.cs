using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : IGameCondition
{
    public bool IsConditionMet(GameConditionsManager context)
    {
        var waveSpawner = context.GetWaveSpawner();
        return waveSpawner != null && waveSpawner.AreAllWavesCompleted();
    }

    public void Execute()
    {
        Debug.Log("¡Ganaste el juego!");
        EventManager.Trigger(EventManager.NameEvent.Win);
    }
}