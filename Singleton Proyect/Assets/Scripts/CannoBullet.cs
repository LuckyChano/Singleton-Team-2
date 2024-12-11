using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : Bullet
{
    private void Start()
    {
        Initialize(
            target: null,
            speed: FlyweightPointer.cannonBullet.speed,
            damage: FlyweightPointer.cannonBullet.damage
        );

        AudioManager.instance.Play("Cannon");
    }
}