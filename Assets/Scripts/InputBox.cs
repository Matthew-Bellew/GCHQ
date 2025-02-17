using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputBox : MonoBehaviour
{
    TMP_InputField Input;
    public static InputBox instance;

    WordGameBase Base;

    void Awake()
    {
        //sets up links to components and other objects
        Input = GetComponent<TMP_InputField>();
        Base = FindObjectOfType<WordGameBase>();

        
        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "InputBox.instance.ResetInput();"
        if (instance != null)
        {
            Debug.LogError("Found more than one InputBox in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Input.text = "";
        //Input.SetText("");

    }

    public void SendInputToBase()
    {
        Debug.Log("Sending contents of Input Box to AnswerInput");
        Base.InputToAnswerInput(Input.text);
    }
}
