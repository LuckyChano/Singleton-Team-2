using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speed;
    private float _damage;

    public void Initialize(Transform target, float speed, float damage)
    {
        _target = target;
        _speed = speed;
        _damage = damage;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) < 0.5f)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        var damageable = _target.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
