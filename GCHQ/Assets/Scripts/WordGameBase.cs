using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGameBase : MonoBehaviour
{
    public List<string> Words = new List<string> {};
    public List<string> WordsLv1 = new List<string> { "HUT", "HAT", "COW", "CAP", "BAT", "EGG", "OFF", "CAT", "SEE", "SEA", "HAY", "EAR", "FAN", "PUT", "LOT", "RED", "ODD", "ODE", "FAT" }; //tip/pit, top/pot, rat/tar, ton/not war/raw pea/ape dog/god
    public List<string> WordsLv2 = new List<string> { "BEAM", "SOUL", "WOOD", "LOUD", "FROG", "BULL", "POKE", "DUCK", "DREG", "SOUP", "FALL", "KING", "LORD", "PANT", "GULF", "BOOT", "BOAT", "HORN", "BIRD", "DRIP", "FIRE", "LOCK", "SELL", "WELL", "LESS", "FISH", "BARN", "WARM", "CITY", "LEAF", "BUSH", "RAIN", "PONY", "FONT", "WASH", "ACHE", "RUDE", "DUAL", "DUEL", "DUET", "DRUM", "BEAT", "SONG", "NOSE", "TANK", "TWIG", "NEWT", "FOUR", "FLAG", "BONE", "SAIL", "HOLE", "HAIR", "LOFT", "CALL", "HELP"};//goat/toga meat/team bare/bear plug/gulp said/dais once/cone lead/deal blue/lube lost/lots cork/rock loin/lion sign/sing/gins hear/hare golf/flog ogre/gore acre/care kiln/link
    public List<string> WordsLv3 = new List<string> { "CLOWN", "MOUSE", "BROWN", "BROOM", "MONTH", "GOOSE", "GEESE", "MOOSE", "SMELL", "BRICK", "TIGER", "MOULD", "PIANO", "QUACK", "CRACK", "BURST", "WATCH", "CHART", "CHAIR", "PAINT", "SQUID", "HEDGE", "GIANT", "CLOUD", "APPLE", "QUEST", "SCENT", "ZEBRA", "ARROW", "POINT", "SMASH", "BERRY", "DRESS", "LIGHT", "SHOOT", "SHOVE", "BUILD", "SPARK", "LAUGH", "GRAND", "PRINT", "TRUST", "BLACK", "GHOST", "BRAWL", "FLOUR", "CREAM", "ONION", "WHEAT", "HORSE", "ALIEN", "PIZZA", "WATER", "LEAVE", "FAIRY", "QUEEN", "TRAIN", "MOUTH", "HIPPO", "RHINO", "SNACK", "SMACK", "TEETH", "TOOTH", "TRUTH", "THIRD", "FIRST", "FIFTH", "MOTOR", "ROTOR", "UTTER", "SQUAT", "REACT", "ALARM", "ALERT", "BAKER" };// earth/heart petal/leapt lemon/melon shrub/brush clean/lance
    public List<string> WordsLv4 = new List<string> { "SEVERE", "MONKEY", "DONKEY", "PIRATE", "FACTOR", "DOCTOR", "PREFER", "FILTHY", "SMELLY", "YELLOW", "INSECT", "STOLEN", "SOLVED", "WOLVES", "BELIEF", "ENRAGE", "ORANGE", "SNEEZE", "NEARBY", "MOULDY", "TOILET", "PERMIT", "GOBLIN", "LISTEN", "SOCKET", "TRAVEL", "SQUARE", "DIRECT", "COWBOY", "ACTIVE", "EMPIRE", "POETRY", "BANANA", "CARPET", "OBJECT", "JESTER", "CHEESE", "SERMON", "COFFEE", "FLOWER", "STRIPE", "WINDOW", "STRONG", "SQUEAK", "BUBBLE", "SECOND", "FOURTH", "DRAGON", "BOTTLE", "BAKERY"  };  //oh fug conker can also be reckon how tf do i program that  oh and mental/lament and garden/danger
    //public List<string> WordsLv5 = new List<string> { "COCONUT", "VOLCANO", "CORRECT", "CURRENT", "SOLDIER", "CHIMNEY", "LEOPARD", "REPTILE", "CRICKET", "CURIOUS", "ABSTAIN", "PROCEED", "EYEBALL", "TRIUMPH", "VICTORY", "DESTROY", "CONQUER", "CONTROL", "SCIENCE", "SILENCE", "DICTATE", "POTTERY", "MONSTER", "BREATHE"}; //termite/emitter deliver/relived
    // going for 6 letters max right now, maybe make it 7? Add "COCONUT" back in?

    //might make the lists into arrays depending what I need them to do
    int CurrentShift;
    public List<int> Shifts = new List<int> { };
    public List<int> ShiftsLv1 = new List<int> { 1, 2, 3 };
    public List<int> ShiftsLv2 = new List<int> { 4, 5 };
    bool ShiftForward = true;
    string EncodedAnswer;

    public ChangeText CodeText;

    public char[] Letters;
    string Answer;
    public string AnswerInput;
    int RandomNumber;
    public GameObject[] MyLetterButtons;
    public int Score = 0;

    //public List<GameObject> LastButtonPressed = new List<GameObject> { };
    GameObject[] ResetBackspace;
    GameObject NewGame;

    void Awake()
    {
        MyLetterButtons = GameObject.FindGameObjectsWithTag("LetterButton");
    }

    void RoundStart()
    {
        // creates a number between 0 and the length of the words array
        RandomNumber = Random.Range(0, Words.Count);
        while (Words[RandomNumber] == Answer)
        {
            RandomNumber = Random.Range(0, Words.Count);
        }

        //gets the word at that number
        Letters = Words[RandomNumber].ToCharArray();
        CheckArray();

        //I'm having the answer be its own variable so other scripts don't have to get both the array and the number variable to check it
        Answer = Words[RandomNumber];
        Debug.Log(Answer);

        GenerateCipher();
        EncodeAnswer();
        CodeText.SetMessage(EncodedAnswer);


        //sets answerinput and answerbox to blank and buttons to active
        ResetButtonsAndInput();

        //this bit scrambles the letter array. count needs to be +1 because int arrays don't include the final number
        for (int LetterCount = Letters.Length - 1; LetterCount > 0; LetterCount--)
        {
            int i = Random.Range(0, LetterCount);
            Debug.Log("At " + LetterCount + ", i is " + i);
            (Letters[i], Letters[LetterCount]) = (Letters[LetterCount], Letters[i]);
        }
        
        CheckArray();

        //sets letterbuttons to active
        foreach (GameObject ButtonObj in MyLetterButtons)
        {
            ButtonObj.GetComponent<WordButton>().ButtonActive(true);
        }

        //resets timer and starts it
        Timer.instance.TimerReset();
        Timer.instance.TimerStart();
        Debug.Log("Timer should show " + Timer.instance.timeRemaining);

    }



    //this is just here so I don't forgot how functions work - https://awesometuts.com/blog/c-sharp-functions/
    /*
    int[] RandomizeIntGenAsAnExampleOfAFunction()
    {
        int sneed = Random.Range(0, count);
        return (sneed);
    }
    */

    //testing Letters array
    void CheckArray()
    {
        foreach (char poop in Letters)
        {
            Debug.Log(poop);
        }
    }

    public void CheckAnswer()
    {
        Debug.Log(AnswerInput);

        //checks There's been as many letters input as the answer has
        if (Answer.Length == AnswerInput.Length)
        {
            if (AnswerInput == Answer)
            {
                StartCoroutine(Win());
            }
            else
            {
                SoundManager.instance.Incorrect();
                ResetButtonsAndInput();
            }
        }
    }

    void GenerateCipher()
    {
        RandomNumber = Random.Range(0, Shifts.Count);
        CurrentShift = Shifts[RandomNumber];

        //it's easier to update the CipherClue here before making the key negative than making a new variable
        if (Random.value >= 0.5)
        {
            ShiftForward = true;
            CipherClue.instance.UpdateClue(CurrentShift, ShiftForward);
        }
        else
        {
            ShiftForward = false;
            CipherClue.instance.UpdateClue(CurrentShift, ShiftForward);
            CurrentShift *= -1;
        }
        //ShiftForward is pretty redundant, should I get rid of it?
    }

    void EncodeAnswer()
    {
        EncodedAnswer = string.Empty;

            foreach (char ch in Answer)
            {
            //char i = ch + CurrentShift;
            char i = (char)((int)ch + CurrentShift);
            if ( i < 65 || i > 90)
            {
                Debug.Log(i);
                Debug.Log(i + " isn't in A-Z. You can't do that, poobrain.");
                i = FixAlphabet(i);
            }

            EncodedAnswer += i;
            }
        Debug.Log("Encoded answer is " + EncodedAnswer);
    }

    IEnumerator Win()
    {

        Timer.instance.TimerStop();
        Debug.Log("Correct!");

        foreach (GameObject ButtonObj in MyLetterButtons)
        {
            ButtonObj.GetComponent<WordButton>().ButtonActive(false);
        }
        Score += 1;
        SoundManager.instance.Correct();

        //removes the word at the current index from the list - it won't reappear unless it is added again, e.g. Words=WordsLv2 brings back any used Lv2 words
        Words.RemoveAt(RandomNumber);

        if (Words.Count == 0)
        {
            //when out of words, call the out of words message and turn off buttons
            AnswerBox.instance.OutofWords();
            //NoButtons();
        }
        else
        {

            //checks score and increases level at certain scores, changing the active words list
            if (Score == 5)
            {
                Words.AddRange(WordsLv2);
                Timer.instance.ChangeTimerLevel(1);
            }
            if (Score == 10)
            {
                RemoveWords(WordsLv1);
            }
            if (Score == 15)
            {
                Words.AddRange(WordsLv3);
                Timer.instance.ChangeTimerLevel(2);
            }
            if (Score == 20)
            {
                RemoveWords(WordsLv2);
                Shifts.AddRange(ShiftsLv2);
            }
            if (Score == 25)
            {
                Words.AddRange(WordsLv4);
                Timer.instance.ChangeTimerLevel(3);
            }
            if (Score == 30)
            {
                RemoveWords(WordsLv3);
            }
            //Wait for 1 seconds
            yield return new WaitForSeconds(1);
            //start new round
            RoundStart();

        }

    }

    void RemoveWords(List<string> LevelToRemove)
    {
        foreach (string word in LevelToRemove)
        {
            Words.Remove(word);
        }
    }

    public void Lose()
    {
        SoundManager.instance.Defeat();
        //NoButtons();
        //AnswerBox.instance.GameOverScore(Score);

        Timer.instance.TimerStop();

        ScreenManager.instance.MainToResult(false, Score);
    }

    public void ResetButtonsAndInput()
    {
        Debug.Log("Resetting buttons and AnswerInput");
        AnswerBox.instance.Reset();
        //InputBox.instance.Reset();
        AnswerInput = "";
        /*
        foreach (var Button in MyLetterButtons)
        {
            Button.GetComponent<WordButton>().ButtonActive(true);
            //Debug.Log("Buttons on");
        }
        */
    }

    public void NoButtons()
    {
        //sets reset, backspace and letter buttons to deactive and new game to active
        foreach (var ResetandBack in ResetBackspace)
        {
            ResetandBack.SetActive(false);
        }

        foreach (var Button in MyLetterButtons)
        {
            Button.SetActive(false);
        }

        NewGame.SetActive(true);

    }

    public void ResetGame()
    {
        //resets score and words and starts a new round
        Score = 0;

        //why the fuck is this line linking them both for the whole game there's no way that's supposed to happen it was working fine before
        //Words = WordsLv1;

        //now I have to use this instead because the last line decided to be a piece of shit
        Words.Clear();
        Words.AddRange(WordsLv1);

        Shifts.Clear();
        Shifts.AddRange(ShiftsLv1);

        Timer.instance.ChangeTimerLevel(0);

        RoundStart();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void Backspace()
    {
        if (AnswerInput.Length > 0)
        {
            AnswerInput = AnswerInput.Remove(AnswerInput.Length - 1, 1);
            AnswerBox.instance.UpdateAnswerBox(AnswerInput);
        }

        /*
        if (LastButtonPressed.Count > 0)
        {
            LastButtonPressed[LastButtonPressed.Count - 1].GetComponent<WordButton>().Reactivate();
            LastButtonPressed.RemoveAt(LastButtonPressed.Count - 1);
        }
        */

    }
    
    public void InputToAnswerInput(string input)
    {
        AnswerInput = input;
    }

    char FixAlphabet(char ch)
    {
        int places;
        if (ch < 65)
        {
            places = (65 - ch);
            ch = (char)((int)91 - places);
        }
        else
        {
            places = (ch - 90);
            ch = (char)((int)64 + places);
        }
        return ch;
    }
}