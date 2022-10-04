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
        //Aiming

        //Walking?

        if (hasWeapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AxeThrow();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                WeaponStartPull();
            }
        }

        if (pulling)
        {
            if (_returnTime < 1)
            {
                weapon.position = GetQuadraticCurvePoint(_returnTime, _pullPosition, curvePoint.position, hand.position);
                _returnTime += Time.deltaTime * 1.5f;
            }
            else
            {
                WeaponCatch();
            }
        }
    }

    public void AxeThrow()
    {
        Debug.Log("AGARRA");

        hasWeapon = false;
        _weaponSc.activated = true;
        _weaponRb.isKinematic = false;
        _weaponRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        weapon.parent = null;
        weapon.eulerAngles = new Vector3(0, -90 + transform.eulerAngles.y, 0);
        weapon.transform.position += transform.right / 5;
        _weaponRb.AddForce(Camera.main.transform.forward * throwPower + transform.up * 2, ForceMode.Impulse);
    }

    //AxeChatch
    public void WeaponStartPull()
    {
        pulling = true;
        _pullPosition = weapon.position;
        _weaponRb.Sleep();
        _weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        _weaponRb.isKinematic = true;
        weapon.eulerAngles = new Vector3(-110, 0, 0);
        _weaponRb.velocity = Vector3.zero;
        _weaponSc.activated = true;
    }

    //AxeReset
    public void WeaponCatch()
    {
        _returnTime = 0;
        pulling = false;
        weapon.parent = hand;
        _weaponSc.activated = false;
        weapon.localEulerAngles = _origLocRot;
        weapon.localPosition = _origLocPos;
        hasWeapon = true;
    }

    private Vector3 GetQuadraticCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        return (uu * p0) + (2 * u * t * p1) + (tt * p2);
    }
}
