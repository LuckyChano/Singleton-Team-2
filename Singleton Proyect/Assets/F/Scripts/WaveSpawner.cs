using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //Este Script Spawnea los enemigos que recorren la pasarela.//////////////////////////////////////////////////////////////////////////////////////////////

    public Transform enemyPrefab;
    public Transform spownPoint;
    private float countdown = 2f;
    private int waveIndex = 0;
    public float timeBetwenWaves = 5f;

    public Text waveCountDownText;

    void Update()
    {
        //Conteo para spownear la wave.
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            SpawnWave();
            countdown = timeBetwenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        //Spownea los enemigos segun la wave.
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Wave Spawned");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spownPoint.position, spownPoint.rotation);
    }
}
