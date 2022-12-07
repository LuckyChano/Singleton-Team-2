using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoBullet : Bullet
{
    private void Start()
    {
        speed = FlyweightPointer.cannonBullet.speed;
        damage = FlyweightPointer.cannonBullet.damage;
        impactRadius = FlyweightPointer.cannonBullet.impactRadius;
    }
}
