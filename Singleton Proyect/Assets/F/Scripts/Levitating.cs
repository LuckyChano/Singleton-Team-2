using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitating : MonoBehaviour
{
    public bool floatup;

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
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * Time.deltaTime, transform.position.z);
        yield return new WaitForSeconds(3f);
        floatup = false;
    }

    IEnumerator FloatingDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
        yield return new WaitForSeconds(3f);
        floatup = true;
    }
}
