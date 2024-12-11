using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : Bullet
{
    private void Start()
    {
        Initialize(
            target: null,
            speed: FlyweightPointer.magicBullet.speed,
            damage: FlyweightPointer.magicBullet.damage
        );

        AudioManager.instance.Play("Magic");
    }
}