using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : IGameCondition
{
    public bool IsConditionMet(PlayerStats stats) => stats.Lives <= 0;

    public void Execute()
    {
        EventManager.Trigger(EventManager.NameEvent.Lose);
    }
}
