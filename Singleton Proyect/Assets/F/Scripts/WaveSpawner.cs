using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Monetization;

public class WaveSpawner : MonoBehaviour
{
    //Este Script Spawnea los enemigos que recorren la pasarela.//////////////////////////////////////////////////////////////////////////////////////////////

    ObjectPool<Enemies> _pool;
    Factory<Enemies> _factory;

    public int stock = 50;

    public Enemies enemy;

    //public Transform enemyPrefab;
    //public Transform spownPoint;
    private float countdown = 2f;
    private int waveIndex = 0;
    public float timeBetwenWaves = 5f;

    public Text waveCountDownText;

    private void Start()
    {
        _factory = new Factory<Enemies>(enemy);
        _pool = new ObjectPool<Enemies>(_factory.Get, TurnOn, TurnOff, stock);
    }

    void Update()
    {
        //Conteo para spawnear la wave.
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetwenWaves;
        }

        countdown -= Time.deltaTime;

        //Para que no sea un numero negativo.
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00'}", countdown);
    }

    //Spawnea los enemigos segun la wave.
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Wave Spawned");
    }

    void SpawnEnemy()
    {
        //Instantiate(enemyPrefab, spownPoint.position, spownPoint.rotation);

        var e = _pool.GetObject();
        e.GetObjectPoolReference(_pool);
        e.transform.position = transform.position;
        e.transform.rotation = transform.rotation;
    }

    public void TurnOn(Enemies b)
    {
        b.gameObject.SetActive(true);
    }

    public void TurnOff(Enemies b)
    {
        b.gameObject.SetActive(false);
    }
}
