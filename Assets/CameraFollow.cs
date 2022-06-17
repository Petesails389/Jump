using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraType;
    [SerializeField] GameObject player;

    private Transform playerTansform;
    private Vector3 offset = new Vector3(0,0,0);

    void Start()
    {
        playerTansform = player.GetComponent<Transform>();
        if (cameraType == 2){
            offset = new Vector3(0,4,-10);
        }
    }

    void Update()
    {
        if (cameraType == 1){
            gameObject.transform.rotation = playerTansform.rotation;
            gameObject.transform.position = playerTansform.position;
            transform.Translate(offset);
        }
        if (cameraType == 2){
            gameObject.transform.rotation = playerTansform.rotation;
            gameObject.transform.position = playerTansform.position;
            transform.Translate(offset);
            gameObject.transform.LookAt(playerTansform.position);
        }
        if (cameraType == 3){
            gameObject.transform.LookAt(playerTansform.position);
        } 
    }
}
