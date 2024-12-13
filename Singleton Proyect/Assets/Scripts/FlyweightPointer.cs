using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    //Orden de datos Bullet (Damage - Radius - Speed)
    public static readonly BulletData cannonBullet = new BulletData(60, 3, 50);
    public static readonly BulletData arrowBullet = new BulletData(80, 0, 25);
    public static readonly BulletData magicBullet = new BulletData(15, 8, 100);
}