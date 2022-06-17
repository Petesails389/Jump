using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float torque;
    [SerializeField] float jumpForce;
    Rigidbody rb;

    private bool isGrounded;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        isGrounded = true;
    }

    public void Move(float direction){
        rb.AddRelativeForce(Vector3.forward * force * direction * Time.deltaTime);
    }
    
    public void Rotate(float turn){
        rb.AddTorque(transform.up * torque * turn * Time.deltaTime);
    }

    public void Jump(){
        if (isGrounded){
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime);
        }
    }
}
