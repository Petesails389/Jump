using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SystemController systemController;
    void Start()
    {
        systemController = GameObject.Find("System").GetComponent<SystemController>();
    }

    public void Restart()
    {
        systemController.Restart();
    }

    public void Resume()
    {
        systemController.Play();
    }
    
    public void Menu()
    {
        print("going to menu. not really but maybe one day");
    }

}
