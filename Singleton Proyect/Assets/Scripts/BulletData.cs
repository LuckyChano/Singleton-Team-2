using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletData
{
    public int damage;
    public int impactRadius;
    public int speed;
    public string particlePrefabName;

    public BulletData(int damage, int radius, int speed, string particlePrefabName)
    {
        this.damage = damage;
        this.impactRadius = radius;
        this.speed = speed;
        this.particlePrefabName = particlePrefabName;
    }
}