using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float SpeedMove;
    public float JumpPower;

    private bool _isGrounded;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    } 

    private void FixedUpdate()
    {
        MovementLogic();

        JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.Translate(movement * SpeedMove * Time.fixedDeltaTime);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0 && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * JumpPower);
        }
    }

    //private void JumpLogic()
    //{
    //    if (Input.GetKeyDown("Jump") && _isGrounded)
    //    {
    //        _rigidbody.AddForce(Vector3.up * JumpPower);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUdate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUdate(collision, false);
    }

    private void IsGroundedUdate(Collision collision, bool value)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = value;
        }
    }
}
