using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraType;
    [SerializeField] Vector3 offset = new Vector3(0,2,-5);

    private GameObject player;
    private Transform playerTansform;

    void Update()
    {
        if (player == null){
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            playerTansform = player.GetComponent<Transform>();
        }
        else {
            if (cameraType == 1){
                gameObject.transform.rotation = playerTansform.rotation;
                gameObject.transform.position = playerTansform.position;
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

    public void SetCameraType(float type){
        cameraType = type;
    }
}
