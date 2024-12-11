using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : Bullet
{
    private void Start()
    {
        Initialize(
            target: null,
            speed: FlyweightPointer.arrowBullet.speed,
            damage: FlyweightPointer.arrowBullet.damage
        );

        AudioManager.instance.Play("Arrow");
    }
}