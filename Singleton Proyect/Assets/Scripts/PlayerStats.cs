using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Money { get; private set; }
    public int Lives { get; private set; }

    public void Initialize(int startingMoney, int startingLives)
    {
        Money = startingMoney;
        Lives = startingLives;
    }

    public void AddMoney(int amount) => Money += amount;

    public void ReduceMoney(int amount) => Money = Mathf.Max(0, Money - amount);

    public void ReduceLife() => Lives = Mathf.Max(0, Lives - 1);

    public void AddLife(int amount) => Lives += amount;
}
