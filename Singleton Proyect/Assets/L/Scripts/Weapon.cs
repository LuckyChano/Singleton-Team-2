using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Parameters")]
    public float rotationSpeed;

    //[HideInInspector]
    [Header("Bools")]
    public bool activated;

    private void Update()
    {
        if (activated)
        {
            transform.localEulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //GetComponent<Rigidbody>().Sleep();
        //GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        //GetComponent<Rigidbody>().isKinematic = false;
        activated = false;
    }
}