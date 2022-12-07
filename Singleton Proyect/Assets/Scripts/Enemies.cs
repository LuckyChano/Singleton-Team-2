using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour, IDamageable
{
    //Este Script se encarga de Guiar a los enemigos por la pasarela de WayPoints.//////////////////////////////////////////////////////////////////////////////////////////

    ObjectPool<Enemies> _OPRef;

    protected Transform target;

    protected int wavepointIndex = 0;

    protected float _life;
    protected float _speed;
    protected float _moneyGain;

    public GameObject deathEffect;

    //Se encarga de regular el daño del enemigo.//
    public void TakeDamage(float amount)
    {
        _life -= amount;
        if (_life <= 0)
        {
            Die();
        }
    }

    //Agrega Dinero cada vez que matas un enemigo y aplica los efectos de muerte del mismo./////////////////////////////////////////////////////
    public void Die()
    {
        GameManager.instance.Money += _moneyGain;
        GameManager.instance.enemiesKill++;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);

        //Destroy(gameObject);

        target = WayPoints.points[0];
        wavepointIndex = 0;
        _OPRef.ReturnObject(this);
    }

    //Le suma uno al index para actualizar el siguiente objetivo.//
    protected void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }

    protected void EndPath()
    {
        GameManager.instance.ReduceLife();

        target = WayPoints.points[0];
        wavepointIndex = 0;
        _OPRef.ReturnObject(this);
    }

    public void GetObjectPoolReference(ObjectPool<Enemies> OPRef)
    {
        _OPRef = OPRef;
    }
}
