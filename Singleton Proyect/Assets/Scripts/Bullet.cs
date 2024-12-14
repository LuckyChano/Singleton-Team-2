using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speed;
    private float _damage;
    private float _impactRadius;
    private string _particlePrefabName;

    public void Initialize(Transform target, float speed, float damage, float impactRadius, string particlePrefabName)
    {
        _target = target;
        _speed = speed;
        _damage = damage;
        _impactRadius = impactRadius;
        _particlePrefabName = particlePrefabName;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        if (!string.IsNullOrEmpty(_particlePrefabName))
        {
            GameObject particles = Resources.Load<GameObject>(_particlePrefabName);
            if (particles != null)
            {
                Instantiate(particles, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"No se encontró el prefab de partículas: {_particlePrefabName}");
            }
        }

        if (_impactRadius > 0f)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _impactRadius);
            foreach (var collider in colliders)
            {
                var damageable = collider.GetComponent<IDamageable>();
                var enemyHealth = collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null && !enemyHealth.IsDead) // Verifica si el enemigo está vivo
                {
                    damageable?.TakeDamage(_damage);
                }
            }
        }
        else
        {
            var damageable = _target.GetComponent<IDamageable>();
            var enemyHealth = _target.GetComponent<EnemyHealth>();
            if (enemyHealth != null && !enemyHealth.IsDead) // Verifica si el enemigo está vivo
            {
                damageable?.TakeDamage(_damage);
            }
        }

        Destroy(gameObject);
    }
}
