using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "TowerDefense/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Stats")]
    public int maxLife;
    public int speed;
    public int moneyGain;
}
