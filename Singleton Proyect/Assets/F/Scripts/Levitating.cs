using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitating : MonoBehaviour
{
    public bool floatup;
    public float timeToLevitate;
    public float speed;

    void Update()
    {
        if (floatup)
        {
            StartCoroutine(FloatingUp());
        }
        else
        {
            StartCoroutine(FloatingDown());
        }
    }

    IEnumerator FloatingUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        yield return new WaitForSeconds(timeToLevitate);
        floatup = false;
    }

    IEnumerator FloatingDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        yield return new WaitForSeconds(timeToLevitate);
        floatup = true;
    }
}
