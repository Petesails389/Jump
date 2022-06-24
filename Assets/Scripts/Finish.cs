using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private SystemController systemController;

    void Start()
    {
        systemController = GameObject.Find("System").GetComponent<SystemController>();    
    }

    void OnTriggerEnter(Collider collision){
        GameObject other = collision.gameObject;
        if (other.tag == "Player"){
            systemController.Finish();
        }
    }
}
