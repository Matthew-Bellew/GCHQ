using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{

    public InputAction QuitAction;

    void Start()
    {
        QuitAction.Enable();
    }

    void Update()
    {
        //quit the game on excape key press
        if (QuitAction.IsPressed())
        {
            Quit();
        }

    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
