using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Rigidbody _weaponRb;
    private Weapon _weaponSc;
    
    private float _returnTime;
    private Vector3 _origLocPos;
    private Vector3 _origLocRot;
    private Vector3 _pullPosition;

    [Header("Public References")]
    public Transform weapon;
    public Transform hand;
    public Transform spine;
    public Transform curvePoint;
    [Space]
    [Header("Parameters")]
    public float throwPower = 30;
    public float cameraZoomOffset = .3f;
    [Space]
    [Header("Bools")]
    public bool walking = true;
    public bool aiming = false;
    public bool hasWeapon = true;
    public bool pulling = false;

    private void Start()
    {
        _weaponRb = weapon.GetComponent<Rigidbody>();
        _weaponSc = weapon.GetComponent<Weapon>();
        _origLocPos = weapon.localPosition;
        _origLocRot = weapon.localEulerAngles;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AxeThrow();
        }
    }

    public void AxeThrow()
    {
        Debug.Log("AGARRA");

        hasWeapon = false;
        //weaponSc.activated = true;
        _weaponRb.isKinematic = false;
        _weaponRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        weapon.parent = null;
        weapon.eulerAngles = new Vector3(0, -90 + transform.eulerAngles.y, 0);
        weapon.transform.position += transform.right / 5;
        _weaponRb.AddForce(Camera.main.transform.forward * throwPower + transform.up * 2, ForceMode.Impulse);


    }

}
