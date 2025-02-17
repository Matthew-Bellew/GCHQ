using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordButton : MonoBehaviour
{
    public char Letter;
    public int Slot;
    public TMP_Text Textbox;
    Button ButtonComponent;
    public WordGameBase Base;

    void Awake()
    {
        //sets up links to components and other objects
        Textbox = GetComponentInChildren<TextMeshProUGUI>();
        ButtonComponent = GetComponent<Button>();
        Base = FindObjectOfType<WordGameBase>();
        Textbox.SetText(Letter.ToString());
    }

    /*
    public void Activate()
    {
        ButtonComponent.interactable = true;
        Textbox.SetText(Letter.ToString());



        Debug.Log("Button " + Slot + " Activated");
        Debug.Log(Base.Letters.Length + " letters");


        //checks if the slot number is bigger than the number of letters
        if (Slot > Base.Letters.Length - 1)
        {
            //deactivates the button if it's redundant
            Debug.Log("Button " + Slot + "is redundant");
            gameObject.SetActive(false);
        }
        else
        {
            //otherwise, sets the button text to the letter with the matching slot number
            ButtonComponent.interactable = true;
            Letter = Base.Letters[Slot];
            //Debug.Log("Button " + Slot + " has " + Letter);
            Textbox.SetText(Letter.ToString());
        }
    }

    */

    public void ButtonActive(bool active)
    {
        ButtonComponent.interactable = active;
    }

    public void AddLetter()
    {
        //Adds the assigned letter to the answerinput, updates the answerbox, deactivates the button and calls the answer check
        Base.AnswerInput += Letter;
        AnswerBox.instance.UpdateAnswerBox(Base.AnswerInput);

        //Base.LastButtonPressed.Add(gameObject);
        //Deactivate();

        Base.CheckAnswer();
    }

    public void PlaySound()
    {
        SoundManager.instance.Type();
    }

}
