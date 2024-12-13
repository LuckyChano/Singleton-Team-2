using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    private EnemyHealth _healthComponent;
    private EnemyMovement _movementComponent;

    void Start()
    {
        if (_enemyData == null)
        {
            Debug.LogError("EnemyData no está asignado al prefab del enemigo.");
            return;
        }

        _healthComponent = GetComponent<EnemyHealth>();
        _movementComponent = GetComponent<EnemyMovement>();

        if (_healthComponent != null)
        {
            _healthComponent.Initialize(_enemyData.maxLife, _enemyData.moneyGain);
        }

        if (_movementComponent != null)
        {
            _movementComponent.Initialize(WayPoints.points, _enemyData.speed);
        }
    }
}