using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : Bullet
{
    private void Start()
    {
        AudioManager.instance.Play("Arrow");
        speed = FlyweightPointer.arrowBullet.speed;
        damage = FlyweightPointer.arrowBullet.damage;
        impactRadius = FlyweightPointer.arrowBullet.impactRadius;
    }
}
