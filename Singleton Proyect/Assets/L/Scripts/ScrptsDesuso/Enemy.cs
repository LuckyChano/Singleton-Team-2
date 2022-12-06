using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ObjectPool<Enemy> _OPRef;
    public float _counter;
    //int maxTime = 4;

    public bool visible = false;
    public bool hit = false;

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        ResetBullet();
        _OPRef.ReturnObject(this);
    }

    public void GetObjectPoolReference(ObjectPool<Enemy> OPRef)
    {
        _OPRef = OPRef;
    }

    public void ResetBullet()
    {
        visible = false;
        hit = false;
    }
}