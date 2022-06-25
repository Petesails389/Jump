using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    SystemController systemController;
    void Start()
    {
        try{
            systemController = GameObject.Find("System").GetComponent<SystemController>();
        }
        catch
        {
            systemController = null;
        }
    }

    public void Restart()
    {
        if(systemController != null){
            systemController.Restart();
        }
    }

    public void Resume()
    {
        if(systemController != null){
            systemController.Play();
        }
    }
    
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit(){
        Application.Quit();
    }
}
