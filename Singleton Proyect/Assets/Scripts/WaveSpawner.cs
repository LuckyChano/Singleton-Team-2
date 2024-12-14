using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Configuración de Oleadas")]
    [SerializeField] private List<WaveConfig> waveConfigs; // Configuración de oleadas
    [SerializeField] private Transform spawnPoint;         // Punto de spawn
    [SerializeField] private float timeBetweenWaves = 5f;  // Tiempo entre oleadas

    [Header("Referencias")]
    [SerializeField] private WaveUIManager waveUIManager;  // Referencia al manejador de UI

    private int _currentWaveIndex = 0; // Índice de la oleada actual
    private float _countdown;          // Temporizador interno
    private int _enemiesRemaining;     // Número de enemigos restantes en la oleada

    public static WaveSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _countdown = timeBetweenWaves;
        waveUIManager.UpdateWaveCounter(_currentWaveIndex + 1);
    }

    private void Update()
    {
        if (_currentWaveIndex >= waveConfigs.Count) return; // Todas las oleadas completadas

        if (_countdown <= 0f && _enemiesRemaining == 0)
        {
            // Solo avanza a la siguiente oleada si no hay enemigos restantes
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

        // Si hay enemigos vivos, muestra "¡Mátalos!", sino, muestra el tiempo restante
        if (_enemiesRemaining > 0)
        {
            waveUIManager.UpdateTimer("¡Mátalos!");
        }
        else
        {
            waveUIManager.UpdateTimer(_countdown);
        }
    }

    public bool AreAllWavesCompleted()
    {
        Debug.Log($"CurrentWave: {waveConfigs.Count}, TotalWaves: {_currentWaveIndex}, EnemiesAlive: {_enemiesRemaining}");
        return _currentWaveIndex >= waveConfigs.Count && _enemiesRemaining == 0;
    }

    private IEnumerator SpawnWave()
    {
        var currentWave = waveConfigs[_currentWaveIndex];
        _currentWaveIndex++;
        _enemiesRemaining = currentWave.enemyCount;  // Establecer el número de enemigos restantes

        waveUIManager.UpdateWaveCounter(_currentWaveIndex + 1);

        for (int i = 0; i < currentWave.enemyCount; i++)
        {
            SpawnEnemy(currentWave.enemyPrefabs[Random.Range(0, currentWave.enemyPrefabs.Count)]);
            yield return new WaitForSeconds(currentWave.spawnInterval);
        }
    }

    private void SpawnEnemy(GameObject prefab)
    {
        var enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        var enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.OnEnemyDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath()
    {
        _enemiesRemaining--;  // Restar 1 cada vez que un enemigo muere
        if (_enemiesRemaining <= 0)
        {
            // Todos los enemigos han muerto, se puede pasar a la siguiente oleada
            _countdown = timeBetweenWaves;  // Resetear el temporizador entre oleadas
        }
    }
}

[System.Serializable]
public class WaveConfig
{
    public List<GameObject> enemyPrefabs; // Lista de posibles enemigos para esta oleada
    public int enemyCount;               // Número de enemigos
    public float spawnInterval;          // Intervalo entre spawns

    public bool IsCompleted() => enemyCount == 0;
}