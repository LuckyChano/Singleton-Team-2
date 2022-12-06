using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScreen
{
    void Activate();
    void Desactivate();
}

public interface Idamageable
{
    void TakeDamage(float damage);
}