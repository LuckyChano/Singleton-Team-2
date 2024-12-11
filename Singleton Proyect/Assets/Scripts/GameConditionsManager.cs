using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditionsManager : MonoBehaviour
{
    private List<IGameCondition> _conditions;

    public void Initialize(List<IGameCondition> conditions)
    {
        _conditions = conditions;
    }

    private void Update()
    {
        foreach (var condition in _conditions)
        {
            if (condition.IsConditionMet(FindObjectOfType<PlayerStats>()))
            {
                condition.Execute();
                break;
            }
        }
    }
}

public interface IGameCondition
{
    bool IsConditionMet(PlayerStats stats);
    void Execute();
}
