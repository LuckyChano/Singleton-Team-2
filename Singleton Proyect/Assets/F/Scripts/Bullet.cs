using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceByFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceByFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceByFrame, Space.World);
    }

    void HitTarget()
    {
        Debug.Log("Hit");
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
