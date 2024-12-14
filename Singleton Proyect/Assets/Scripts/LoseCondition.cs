using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : IGameCondition
{
    public bool IsConditionMet(GameConditionsManager context)
    {
        var playerStats = context.GetPlayerStats();
        return playerStats != null && playerStats.Lives <= 0;
    }

    public void Execute()
    {
        Debug.Log("¡Perdiste el juego!");
    }
}
