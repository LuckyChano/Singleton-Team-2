using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly FlyweightEnemy orc = new FlyweightEnemy
    {
        maxLife = 100,
        speed = 10,
        moneyGain = 50
    };

    public static readonly FlyweightEnemy esqueletons = new FlyweightEnemy
    {
        maxLife = 50,
        speed = 20,
        moneyGain = 25
    };

    public static readonly FlyweightBullet cannonBullet = new FlyweightBullet
    {
        speed = 60,
        damage = 50,
        impactRadius = 3
    };

    public static readonly FlyweightBullet arrowBullet = new FlyweightBullet
    {
        speed = 80,
        damage = 25,
        impactRadius = 0
    };

    public static readonly FlyweightBullet magicBullet = new FlyweightBullet
    {
        speed = 15,
        damage = 100,
        impactRadius = 8
    };
}
