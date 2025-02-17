using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{

    public TMP_Text Textbox;

    void Awake()
    {
        //sets up links to components and other objects
        Textbox = GetComponent<TextMeshProUGUI>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMessage(string Message)
    {
        //either way works
        //Textbox.SetText(Message);
        //Textbox.text = Message;
        Textbox.SetText(Message);
    }
}
