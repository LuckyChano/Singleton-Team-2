using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 moveDir;
    Vector2 initPos;

    [SerializeField] Transform stick = null;
    [SerializeField] float maxMagnitude = 65;


    private void Start()
    {
        initPos = stick.transform.position;
    }


    public Vector3 MaxMoveForStick()
    {
        Vector3 moveDirForPlayer = new Vector3(moveDir.x, 0, moveDir.y);

        moveDirForPlayer = moveDirForPlayer / maxMagnitude;

        return moveDirForPlayer;
    }


    public void OnDrag(PointerEventData eventData)
    {
        moveDir = Vector3.ClampMagnitude(eventData.position - initPos, maxMagnitude);
        stick.position = (Vector3)initPos + moveDir;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        stick.position = initPos;
        moveDir = Vector3.zero;
    }
}
