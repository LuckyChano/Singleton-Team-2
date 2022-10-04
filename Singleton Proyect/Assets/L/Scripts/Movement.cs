using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : Entity
{
    public Rigidbody rb;
    public FootSensor footSensor;

    public float walkSpeed = 7f;
    public float runSpeedMultiplier = 1.5f;
    public float jumpForce = 10f;
    public float dashForce = 12f;

    private Vector3 _inputVector;
    private bool _isMoving;
    private bool _canMove = true;
    private bool _canDash = true;
    private bool _isStuned;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
    }

    public bool CanMove
    {
        get
        {
            return _canMove;
        }
        set
        {
            _canMove = value;
        }
    }

    public bool CanDash
    {
        get
        {
            return _canDash;
        }
        set
        {
            CanDash = value;
        }
    }

    public bool IsStuned
    {
        get
        {
            return _isStuned;
        }
    }

    public virtual void MoveMe(float verAxis, float horAxis)
    {
        if (verAxis != 0 || horAxis != 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        if (CanMove)
        {
            _inputVector.x = horAxis;
            _inputVector.z = verAxis;
            _inputVector.y = 0;

            if (_inputVector.magnitude > 1)
            {
                _inputVector.Normalize();
            }

            _isStuned = false;
        }
        else
        {
            _inputVector.x = 0;
            _inputVector.z = 0;
            _inputVector.y = 0;

            _isStuned = true;
        }
    }

    public virtual void Run()
    {
        if (footSensor.isGrownded && CanMove)
        {
            _inputVector *= runSpeedMultiplier;
        }
    }

    public virtual void FixedMove()
    {
        if (_inputVector.magnitude > 0)
        {
            rb.MovePosition(rb.position + (transform.right * _inputVector.x + transform.forward * _inputVector.z) * walkSpeed * Time.fixedDeltaTime);
        }
    }

    public virtual void Jump()
    {
        if (footSensor.isGrownded && CanMove)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //AudioManager.instance.Play("PlayerJump");
        }
    }

    public virtual void Dash(float verAxis, float horAxis)
    {
        StartCoroutine(Dasher(verAxis, horAxis));
    }

    //Corregir.
    public IEnumerator Dasher(float verAxis, float horAxis)
    {
        if (CanDash)
        {
            if (horAxis != 0 && verAxis == 0)
                rb.AddForce((transform.right * horAxis).normalized * dashForce, ForceMode.Impulse);

            if (horAxis == 0 && verAxis != 0)
                rb.AddForce((transform.forward * verAxis).normalized * dashForce, ForceMode.Impulse);

            if (horAxis == 0 && verAxis == 0)
                rb.AddForce((transform.forward * 1).normalized * dashForce, ForceMode.Impulse);

            _canDash = false;
        }

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }
}
