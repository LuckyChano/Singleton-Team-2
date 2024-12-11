using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public int maxLife;
    public int speed;
    public int moneyGain;

    public EnemyData(int maxLife, int speed, int moneyGain)
    {
        this.maxLife = maxLife;
        this.speed = speed;
        this.moneyGain = moneyGain;
    }
}
