using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : IGameCondition
{
    private readonly float _targetMoney;

    public WinCondition(float targetMoney) => _targetMoney = targetMoney;

    public bool IsConditionMet(PlayerStats stats) => stats.Money >= _targetMoney;

    public void Execute()
    {
        EventManager.Trigger(EventManager.NameEvent.Win);
    }
}
