using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;

    void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        movement.Strafe(Input.GetAxis("Horizontal"));
        movement.Move(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Jump") > 0){
            movement.Jump();
        }

    }
}
