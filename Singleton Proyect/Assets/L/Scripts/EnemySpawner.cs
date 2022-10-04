using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Bullet bullet;
    ObjectPool<Bullet> _pool;
    public int stock;
    Factory<Bullet> _factory;

    public int maxTime;
    float _counter;

    void Start()
    {
        _factory = new Factory<Bullet>();
        _pool = new ObjectPool<Bullet>(_factory.Get, TurnOn, TurnOff, stock);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var b = _pool.GetObject();
            b.transform.position = transform.position;
            b.transform.forward = transform.forward;
        }

        _counter += Time.deltaTime;

        if (_counter >= maxTime)
        {
            ResetBullet();
            //_pool.ReturnObject(b);
        }

    }

    public void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
    }

    public void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    }

    public void ResetBullet()
    {
        _counter = 0;
    }
}


