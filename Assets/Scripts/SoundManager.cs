using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource Audio;
    public AudioClip CorrectSound;
    public AudioClip IncorrectSound;
    public AudioClip DefeatSound;
    public AudioClip TypeSound;

    public static SoundManager instance;

    void Awake()
    {
        //sets up links to components and other objects
        Debug.Log("AnswerBox Started");
        Audio = GetComponent<AudioSource>();

        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "SoundManager.instance.UpdateClue(5, true);"
        if (instance != null)
        {
            Debug.LogError("Found more than one SoundManager in the scene. Destroying the newest one.");
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

    public void Correct()
    {
        Audio.PlayOneShot(CorrectSound, 1);
    }


    public void Incorrect()
    {
        Audio.PlayOneShot(IncorrectSound, 0.5F);
    }

    public void Defeat()
    {
        Audio.PlayOneShot(DefeatSound, 1);
    }

    public void Type()
    {
        Audio.PlayOneShot(TypeSound, 1);
    }
}
