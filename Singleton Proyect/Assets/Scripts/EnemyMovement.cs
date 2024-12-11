using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wavepointIndex = 0;
    private float _speed;

    public void Initialize(Transform[] waypoints, float speed)
    {
        _target = waypoints[0];
        _wavepointIndex = 0;
        _speed = speed;
    }

    private void Update()
    {
        if (_target == null) return;

        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.5f)
        {
            GetNextWaypoint(WayPoints.points);
        }
    }

    private void GetNextWaypoint(Transform[] waypoints)
    {
        _wavepointIndex++;
        _target = _wavepointIndex < waypoints.Length ? waypoints[_wavepointIndex] : null;
    }
}
