using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class SystemController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float levelLength = 100f;
    [SerializeField] float levelSpeed;
    [SerializeField] string levelName;
    [SerializeField] string nextLevelName;
    [SerializeField] string endText = "Level Complete!";
    [SerializeField] string startInfo = "";
    [SerializeField] string endInfo = "";

    private GameObject finishCollider;
    private GameObject player;
    private GameObject mainCamera;
    private GameObject scoreText;
    private GameObject infoText;
    private GameObject mainText;
    private GameObject pauseMenu;

    private float score = 0f;
    private float time = 0f;
    private bool running = true;
    private float oldPauseAxis;

    void Start()
    {
        finishCollider = GameObject.Find("FinishCollider");
        finishCollider.transform.position = new Vector3(0,14,levelLength);


        mainCamera = GameObject.Find("Camera");
        scoreText = GameObject.Find("ScoreText");
        infoText = GameObject.Find("InfoText");
        mainText = GameObject.Find("MainText");
        pauseMenu = GameObject.Find("Menu");

        Restart();
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
        StartCoroutine(GameEnd());
    }

    public void Restart(){
        if (player != null){
            Destroy(player);
        }
        player = Instantiate(playerPrefab, new Vector3(0,1,0), Quaternion.identity);
        mainCamera.GetComponent<CameraFollow>().SetCameraType(2);
        Pause(false);

        //score
        time = 0f;
        score = 0f;

        StartCoroutine(GameStart());
    }

    IEnumerator GameStart(){
        infoText.GetComponent<TMP_Text>().text = startInfo;
        mainText.GetComponent<TMP_Text>().text = levelName;
        yield return new WaitForSeconds(0.5f);
        Play();
        yield return new WaitForSeconds(0.5f);
        mainText.GetComponent<TMP_Text>().text = "";
    }

    IEnumerator GameEnd(){
        infoText.GetComponent<TMP_Text>().text = endInfo;
        mainText.GetComponent<TMP_Text>().text = endText;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevelName);
    }

    public void Play()
    {
        running = true;
        player.GetComponent<PlayerMovement>().Play();
        pauseMenu.SetActive(false);
    }

    public void Pause(bool menu = true)
    {
        running = false;
        player.GetComponent<PlayerMovement>().Pause();
        pauseMenu.SetActive(menu);
    }
}
