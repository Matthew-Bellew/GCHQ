using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public GameObject Title;
    public GameObject Tutorial;
    public GameObject Tut1;
    public GameObject Tut2;
    public GameObject Main;
    public GameObject Result;
    public ChangeText ResultTitle;
    public ChangeText ResultText;

    public static ScreenManager instance;


    void Awake()
    {
        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "ScreenManager.instance.MainToResult(false, 5);"
        if (instance != null)
        {
            Debug.LogError("Found more than one ScreenManager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Title.SetActive(true);
        Tutorial.SetActive(false);
        Main.SetActive(false);
        Result.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TitleToTutorial()
    {
        Title.SetActive(false);
        Tutorial.SetActive(true);
        Tut1.SetActive(true);
        Tut2.SetActive(false);
    }

    public void Tut1ToTut2()
    {
        Tut1.SetActive(false);
        Tut2.SetActive(true);
    }

    public void TutorialtoMain()
    {
        Tutorial.SetActive(false);
        Main.SetActive(true);
    }

    public void MainToResult(bool win, int score)
    {
        Main.SetActive(false);
        Result.SetActive(true);
        string words = " words.";
        if (score == 1)
        {
            words = " word.";
        }

        if (win == false)
        {
            ResultTitle.SetMessage("GAME OVER!");
            ResultText.SetMessage("You cracked " + score + words);
        }
        else
        {
            ResultTitle.SetMessage("YOU WIN!");
            ResultText.SetMessage("");
        }
    }

    public void ResultToTitle()
    {
        Result.SetActive(false);
        Title.SetActive(true);
    }
}
