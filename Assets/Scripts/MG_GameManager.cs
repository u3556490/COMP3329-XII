using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool startPlaying;

    public MG_BeatScroller bs;
    public static MG_GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public Text scoreText;
    public Text multiplierText;

    public int[] multiplierThresholds;
    public int currentMultiplier = 1;
    public int multiplerTracker;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
        currentMultiplier = 1;
        multiplierText.text = "Multiplier: X" + currentMultiplier;
        multiplerTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bs.hasStarted = true;
                music.Play();
            }
        }
    }

    public void noteHit()
    {
        //Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplerTracker++;
            if (multiplerTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplerTracker = 0;
                currentMultiplier++;
                multiplierText.text = "Multiplier: X"+currentMultiplier;
            }
        }

        //currentScore += scorePerNote*currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void normalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        noteHit();

    }

    public void goodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        noteHit();

    }

    public void perfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        noteHit();

    }

    public void noteMiss()
    {
        Debug.Log("Miss");

        currentMultiplier = 1;
        multiplerTracker = 0;
        multiplierText.text = "Multiplier: X" + currentMultiplier;
    }
}
