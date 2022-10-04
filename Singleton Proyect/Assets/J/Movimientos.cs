using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : Entity
{
    [SerializeField] JoyController joyController;
    [SerializeField] float speed = 5;
    [SerializeField] LayerMask floorMask;


    void Update()
    {
        transform.position += joyController.MaxMoveForStick() * Time.deltaTime * speed;

        if (Input.touchCount <= 0) return;

        Touch firstTouch = Input.touches[0];
        if (firstTouch.phase == TouchPhase.Began)
        {
            Ray touchRay = Camera.main.ScreenPointToRay(firstTouch.position);
            RaycastHit hit;
            if (Physics.Raycast(touchRay, out hit, 10000, floorMask, QueryTriggerInteraction.Ignore))
            {
                transform.position = hit.point;
            }
        }
    }

    public void CollectBuff()
    {
        StartCoroutine(SpeedCoroutine());
    }

    IEnumerator SpeedCoroutine()
    {
        while (speed < speed + 5)
        {
            speed += 2 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
