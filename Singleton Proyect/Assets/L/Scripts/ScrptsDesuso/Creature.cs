using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private void Start()
    {
        EventManager.Subscribe(EventManager.NameEvent.Fear, PlayerScream);
    }

    void PlayerScream(params object[] parameters)
    {
        Debug.Log("El player me causo Fear, salgo corriendo por mi vida");
    }
}
