using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Transform _target;
    private float _fireCooldown;

    private void Update()
    {
        FindClosestTarget();
        HandleShooting();
    }

    private void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= range)
            {
                closestDistance = distance;
                closestTarget = enemy.transform;
            }
        }

        _target = closestTarget;
    }

    private void HandleShooting()
    {
        if (_target == null) return;

        if (_fireCooldown <= 0)
        {
            Shoot();
            _fireCooldown = 1 / fireRate;
        }

        _fireCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        bullet.Initialize(_target, 10f, 25f); // Ejemplo de velocidad y daño.
    }
}