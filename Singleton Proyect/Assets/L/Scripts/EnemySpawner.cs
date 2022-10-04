using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPf;
    
    public Transform[] spawnPoints;
    public Enemy[] enemy;
    
    ObjectPool<Enemy> _pool;
    Factory<Enemy> _factory;

    public int stock;

    public float _counter;
    public int maxTime = 4;

    void Start()
    {
        _factory = new Factory<Enemy>(enemyPf);
        _pool = new ObjectPool<Enemy>(_factory.Get, TurnOn, TurnOff, stock);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (enemy[i] == null)
            {
                var e = _pool.GetObject();
                e.GetObjectPoolReference(_pool);
                enemy[i] = e;
                enemy[i].visible = true;
                e.transform.position = spawnPoints[i].transform.position;
            }
        }

    }

    void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= maxTime)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {

                if (!enemy[i].visible)
                {
                    var e = _pool.GetObject();
                    e.GetObjectPoolReference(_pool);
                    enemy[i] = e;
                    enemy[i].visible = true;
                    e.transform.position = spawnPoints[i].transform.position;
                }
            }
            _counter = 0;
        }
    }

    public void TurnOn(Enemy b)
    {
        b.gameObject.SetActive(true);
    }

    public void TurnOff(Enemy b)
    {
        b.gameObject.SetActive(false);
    }
}


