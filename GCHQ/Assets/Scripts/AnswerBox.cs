using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerBox : MonoBehaviour
{
    public TMP_Text Textbox;
    WordGameBase Base;
    public static AnswerBox instance;

    void Awake()
    {
        //sets up links to components and other objects
        Debug.Log("AnswerBox Started");
        Textbox = GetComponent<TextMeshProUGUI>();

        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "AnswerBox.instance.UpdateClue(5, true);"
        if (instance != null)
        {
            Debug.LogError("Found more than one AnswerBox in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

    }

    public void UpdateAnswerBox(string AnswerInput)
    {
        Textbox.SetText(AnswerInput);

    }

    public void Reset()
    {
        Debug.Log("AnswerBox Reset");
        Textbox.SetText("");
    }

    public void GameOverScore(int Score)
    {
        Textbox.SetText("GAME OVER! YOUR SCORE IS " + Score);
    }

    public void OutofWords()
    {
        Textbox.SetText("You win - I'm out of words! Your time is " + Timer.instance.PlayTimeClock());
    }


}
