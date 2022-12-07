using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //Este Script Se encarga del daño a los enemigos y los efectos de las bullets.//////////////////////////////////////////////////////////////////////////////

    public Transform target;
    
    public GameObject impactEffect;

    public float speed;

    public float impactRadius;

    public float damage;

    private void Start()
    {
        speed = FlyweightPointer.cannonBullet.speed;
        damage = FlyweightPointer.cannonBullet.damage;
        impactRadius=FlyweightPointer.cannonBullet.impactRadius;
    }

    public void Seek(Transform _target)
    {
        target = _target;
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
        transform.LookAt(target);
    }

    //Se fija si el enemigo golpeado por la bullet tiene un radio de impacto mayor a 0, si es asi Explota(Daño area) si no es un single hit y Destroys el bullet.
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (impactRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    //Dispara una esfera con cierto radio para checkear que Objetos con el tag "Enemy" golpea. Les hace daño.
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, impactRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    //Daña a los enemigos.
    void Damage(Transform enemy)
    {
        var e = enemy.GetComponent<IDamageable>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

}
