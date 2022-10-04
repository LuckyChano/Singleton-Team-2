using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float MagnetSpeed;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, MagnetSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (transform.childCount > 1)
        {
            Destroy(gameObject);
        }
    }
}
