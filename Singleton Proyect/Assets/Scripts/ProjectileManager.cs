using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public void SpawnProjectile(GameObject bulletPrefab, Transform firePoint, Transform target, BulletData bulletData)
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Initialize(target, bulletData.speed, bulletData.damage, bulletData.impactRadius, bulletData.particlePrefabName);
        }
        else
        {
            Debug.LogError("No se encontró el componente Bullet en el prefab de proyectil.");
        }
    }
}
