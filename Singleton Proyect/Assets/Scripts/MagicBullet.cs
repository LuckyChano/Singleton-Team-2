using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : Bullet
{
    private void Start()
    {
        AudioManager.instance.Play("Magic");
        speed = FlyweightPointer.magicBullet.speed;
        damage = FlyweightPointer.magicBullet.damage;
        impactRadius = FlyweightPointer.magicBullet.impactRadius;
    }
}
