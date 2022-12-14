using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> where T : MonoBehaviour
{
    T _prefab;

    //T prefab;

    public Factory(T prefab)
    {
        _prefab = prefab;
    }

    public T Get()
    {
        return GameObject.Instantiate(_prefab);
    }
}
