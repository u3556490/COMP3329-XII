using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_2GM : MonoBehaviour
{
    public static int GM2score;
    public Text GM2scoreText;
    //frequency of notes dropping
    public float noteDropFrequency;
    public static float totalTimeCount = 0;
    //play audio once spacebar is pressed
    public static AudioSource GM2Audio;
    public bool playAudio = true;
    //start after a delay
    public int delayStartTime;
    public float delayTimeCount = 0;
    public bool delayStart = false;
    public bool gameStarted = false;
    public static bool showResult = false;
    //testing var only, will delete soon
    public KeyCode justATestingKey;
    //font
    Text m_Text;
    public Font m_Font;

    //representing if there're notes falling in column X(1-8)
    public static int[] noteDropCode = new int[8];

    void Awake()
    {
        GM2Audio = GetComponent<AudioSource>();
        //set all columns to 1 
        for (int i = 0; i < 8; i++)
        {
            noteDropCode[i] = 1;
        }
    }
    void Start()
    {
        m_Text = GetComponent<Text>();
        GM2Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GM2score = Activator.GM2ActivatorScoreCount;
        string GM2ScoreShow = GM2score.ToString();
        GM2scoreText.font = m_Font;
        GM2scoreText.text = "Score " + GM2ScoreShow;

        //testing code only, will delete soon
        if (Input.GetKeyDown(justATestingKey))
        {
            GM2Audio.Stop();
        }


        if ((GM2_Panel_pop.gameStart) && (playAudio))
        {
            Debug.Log("songs");
            playAudio = false;
            GM2Audio.Play();
            gameStarted = true;
        }
        if ((!GM2Audio.isPlaying) && (!GM2_pausePanel.paused))
        {
            GM2_Panel_pop.gameStart = false;
            //Debug.Log("turned false");
            if (gameStarted)
            {
                showResult = true;
                //Debug.Log(showResult);
            }
        }


        //set all columns to 1 
        for (int i = 0; i < 8; i++)
        {
            noteDropCode[i] = 1;
        }
        //timecount only if te game started
        if (GM2_Panel_pop.gameStart)
        {
            totalTimeCount += Time.deltaTime;
            delayTimeCount += Time.deltaTime;
        }
        //detect if the starting time passed or not
        if (delayTimeCount > delayStartTime)
        {
            delayStart = true;
        }
        if ((totalTimeCount >= noteDropFrequency) && (delayStart))
        {
            totalTimeCount = 0;
            int numberOfNotesDropping = Random.Range(1, 3);
            //set to 2 if the column is going to fall a note
            for (int i = 0; i < numberOfNotesDropping; i++)
            {
                int ActivatorDropping = Random.Range(0, 7);
                noteDropCode[ActivatorDropping] = 2;
            }
        }
    }
}
