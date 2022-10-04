using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> where T : MonoBehaviour
{
    T _prefab;

    public T Get()
    {
        return GameObject.Instantiate(_prefab);
    }
}
