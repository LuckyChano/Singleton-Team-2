using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    public GameObject seekTarget;

    public float maxSpeed;
    [Range(0, 0.1f)]
    public float maxForce;
    private Vector3 _velocity;

    public float viewRadius;


    void Update()
    {
        AddForce(Seek(seekTarget.transform.position));

        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        Vector3 steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        return steering;
    }

    void AddForce(Vector3 force)
    {
        _velocity += force;
        _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
