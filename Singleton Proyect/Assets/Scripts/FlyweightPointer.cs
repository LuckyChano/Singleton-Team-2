using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    // Orden de datos Bullet (Damage - Radius - Speed)
    public static readonly BulletData arrowBullet = new BulletData(25, 0, 80, "ArrowParticles");
    public static readonly BulletData cannonBullet = new BulletData(50, 4, 60, "CannonParticles");
    public static readonly BulletData magicBullet = new BulletData(100, 8, 15, "MagicParticles");
}