using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float strafeForce;
    [SerializeField] float jumpSpeed;
    [SerializeField] int groundLayer;

    private Rigidbody rb;

    private bool isGrounded = true;
    private bool running = true;

    private Vector3 velocity;
    private Vector3 angularVelocity;

    void Awake(){
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Move(float multiplier, bool absolute = false){
        if(rb != null){
            if(absolute){
                rb.AddForce(Vector3.forward * force * multiplier * Time.deltaTime);
            } 
            else {
                rb.AddRelativeForce(Vector3.forward * force * multiplier * Time.deltaTime);
            }
        }
    }
    
    public void Strafe(float multiplier){
        rb.AddForce(Vector3.right * strafeForce * multiplier * Time.deltaTime);
    }

    public void Jump(){
        if (isGrounded){
            rb.velocity = new Vector3(0, jumpSpeed, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision){
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject other = contact.otherCollider.gameObject;
            if (other.layer == groundLayer) {
                isGrounded = true;
            }
        }
    }
    
    void OnCollisionExit(Collision collision){
        GameObject other = collision.gameObject;
        if (other.layer == groundLayer) {
            isGrounded = false;
        }
    }
    public void Play()
    {
        if (!running){
            running = true;
            rb.isKinematic = false;
            rb.velocity = velocity;
            rb.angularVelocity = angularVelocity;
        }
    }

    public void Pause()
    {
        if(running){
            running = false;
            velocity = rb.velocity;
            angularVelocity = rb.angularVelocity;
            rb.isKinematic = true;
        }
    }
}
