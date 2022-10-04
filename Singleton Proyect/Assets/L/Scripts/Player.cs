using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerLifeSistem
{
    private Controles _playerControl;

    void Start()
    {
        _playerControl = new Controles(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            EventManager.Trigger(EventManager.NameEvent.Fear, transform.position);
    }
}
