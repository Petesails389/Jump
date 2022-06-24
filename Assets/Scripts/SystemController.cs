using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SystemController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float levelLength = 100f;
    [SerializeField] float levelSpeed;

    private GameObject finishCollider;
    private GameObject player;
    private GameObject mainCamera;
    private GameObject scoreText;
    private GameObject pauseMenu;

    private float score = 0f;
    private float time = 0f;
    private bool running = true;
    private float oldPauseAxis;

    void Start()
    {
        finishCollider = GameObject.Find("FinishCollider");
        finishCollider.transform.position = new Vector3(0,14,levelLength);

        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);

        mainCamera = GameObject.Find("Camera");
        scoreText = GameObject.Find("ScoreText");
        pauseMenu = GameObject.Find("Menu");

        Play();
    }

    void Update()
    {
        if(running){    
            //movement
            player.GetComponent<PlayerMovement>().Move(levelSpeed, true);

            //death
            if(player.transform.position.y < 0f){
                mainCamera.GetComponent<CameraFollow>().SetCameraType(3);
            }
            if(player.transform.position.y < -10f){
                Restart();
            }

            //score
            time += Time.deltaTime;
            float pos = player.transform.position.z;
            score = (float) Math.Round(pos + 5*(pos/time));
            scoreText.GetComponent<TMP_Text>().text = score.ToString();

            if (Input.GetAxis("Pause") > 0){
                if (oldPauseAxis == 0){
                    Pause();
                }
            }
            oldPauseAxis = Input.GetAxis("Pause");
        }
        else {
            if (Input.GetAxis("Pause") > 0){
                if (oldPauseAxis == 0){
                    Play();
                }
            }
            oldPauseAxis = Input.GetAxis("Pause");
        }
    }

    public void Finish(){
        print("game over");
    }

    public void Restart(){
        if(!running){
            Play();
        }
        Destroy(player);
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        mainCamera.GetComponent<CameraFollow>().SetCameraType(2);

        //score
        time = 0f;
        score = 0f;
    }

    public void Play()
    {
        running = true;
        player.GetComponent<PlayerMovement>().Play();
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        running = false;
        player.GetComponent<PlayerMovement>().Pause();
        pauseMenu.SetActive(true);
    }
}
