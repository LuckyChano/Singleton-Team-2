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
    [SerializeField] private Transform head;
    [SerializeField] private string bulletType;

    private Transform _target;
    private float _fireCooldown;

    private void Update()
    {
        FindClosestTarget();
        RotateTowardsTarget();
        HandleShooting();
    }

    private void RotateTowardsTarget()
    {
        if (_target == null) return;

        Vector3 direction = _target.position - head.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(head.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
        head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= range) // Dentro del rango
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
    private BulletData GetBulletData()
    {
        return bulletType switch
        {
            "cannon" => FlyweightPointer.cannonBullet,
            "arrow" => FlyweightPointer.arrowBullet,
            "magic" => FlyweightPointer.magicBullet,
            _ => null,
        };
    }

    private void PlayShootSound()
    {
        string soundName = bulletType switch
        {
            "arrow" => "ArrowShoot",
            "cannon" => "CannonShoot",
            "magic" => "MagicShoot",
            _ => null,
        };

        if (!string.IsNullOrEmpty(soundName))
        {
            AudioManager.instance.Play(soundName);
        }
    }

    private void Shoot()
    {
        if (_target == null) return;

        ProjectileManager projectileManager = GetComponent<ProjectileManager>();
        if (projectileManager != null)
        {
            BulletData bulletData = GetBulletData();
            projectileManager.SpawnProjectile(bulletPrefab, firePoint, _target, bulletData);
            PlayShootSound();
        }
        else
        {
            Debug.LogError("No se encontró el componente ProjectileManager.");
        }
    }
}