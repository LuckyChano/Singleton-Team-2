using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Este Script se encarga de Guiar a los enemigos por la pasarela de WayPoints.//////////////////////////////////////////////////////////////////////////////////////////

    public float speed;

    private Transform target;

    private int wavepointIndex = 0;

    public int health = 100;

    public int moneyGain = 50;

    public GameObject deathEffect;


    void Start()
    {
        target = WayPoints.points[0];    
    }

    //Se encarga de regular el daño del enemigo.//
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    //Agrega Dinero cada vez que matas un enemigo y aplica los efectos de muerte del mismo./////////////////////////////////////////////////////
    void Die()
    {
        GameManager.instance.Money += moneyGain;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);

        Destroy(gameObject);
    }

    void Update()
    {
        //Desplaza a la unidad y la hace mirar en esa direccion.//
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        //Se fija si ya llegaste.//
        if (Vector3.Distance(transform.position, target.position) <= 3f)
        {
            GetNextWaypoint();
        }
    }

    //Le suma uno al index para actualizar el siguiente objetivo.//
    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    } 

    void EndPath()
    {
        GameManager.instance.ReduceLife();
        Destroy(gameObject);
    }


}
