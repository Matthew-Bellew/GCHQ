using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CipherClue : MonoBehaviour
{

    public TMP_Text Textbox;
    public static CipherClue instance;

    void Awake()
    {
        //sets up links to components and other objects
        Textbox = GetComponentInChildren<TextMeshProUGUI>();

        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "CipherClue.instance.UpdateClue(5, true);"
        if (instance != null)
        {
            Debug.LogError("Found more than one CipherClue in the scene. Destroying the newest one.");
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

    public void UpdateClue(int shift, bool forward)
    {
        string direction;
        string places = "places";

        //directions are flipped because this describes going in reverse to solve them
        if (forward == true)
        {
            direction = "back";
        }
        else
        {
            direction = "forward";

        }

        if (shift == 1)
        {
            places = "place";
        }
        Textbox.SetText("Send letters\n\n" + shift + " " + places + "\n\n" + direction);
    }

}
