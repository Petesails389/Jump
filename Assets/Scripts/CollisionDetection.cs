using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private SystemController systemController;

    void Start()
    {
        systemController = GameObject.Find("System").GetComponent<SystemController>();    
    }

    void OnCollisionEnter(Collision collisions){
        foreach(ContactPoint collision in collisions.contacts){
            GameObject other = collision.otherCollider.gameObject;
            if (other.tag == "Player"){
                systemController.Restart();
            }
        }
    }
}
