using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Este Script se encarga de Guiar a los enemigos por la pasarela de WayPoints.//////////////////////////////////////////////////////////////////////////////////////////

    public float speed;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];    
    }

    void Update()
    {
        //Desplaza a la unidad y la hace mirar en esa direccion.//
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        //Se fija si ya llegaste.//
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    //Le suma uno al index para actualizar el siguiente objetivo.//
    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    } 


}
