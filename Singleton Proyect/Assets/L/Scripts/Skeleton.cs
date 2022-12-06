using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        _life = FlyweightPointer.orc.maxLife;
        _speed = FlyweightPointer.orc.speed;
        _moneyGain = FlyweightPointer.orc.moneyGain;
        target = WayPoints.points[0];
    }

    void Update()
    {
        //Desplaza a la unidad y la hace mirar en esa direccion.//
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        //Se fija si ya llegaste.//
        if (Vector3.Distance(transform.position, target.position) <= 3f)
        {
            GetNextWaypoint();
        }
    }
}
