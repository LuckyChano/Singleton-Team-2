using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Monetization;

public class WaveSpawner : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Configuración de Oleadas")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int waves;
    [SerializeField] private float timeBetweenWaves;

    private int _currentWave = 0;
    private float _countdown;

    private void Start()
    {
        _countdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (_countdown <= 0f && _currentWave < waves)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave()
    {
        _currentWave++;
        for (int i = 0; i < _currentWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        var movement = enemy.GetComponent<EnemyMovement>();
        var health = enemy.GetComponent<EnemyHealth>();

        movement.Initialize(WayPoints.points, FlyweightPointer.orc.speed);
        health.Initialize(FlyweightPointer.orc.maxLife, FlyweightPointer.orc.moneyGain);
    }
}
