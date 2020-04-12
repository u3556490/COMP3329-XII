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

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float misses;

    public GameObject results_screen;
    public Text percentHit, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
        currentMultiplier = 1;
        multiplierText.text = "Multiplier: X" + currentMultiplier;
        multiplerTracker = 0;

        totalNotes = FindObjectsOfType<MG_NoteObject>().Length;
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
        } else
        {
            if (!music.isPlaying && !results_screen.activeInHierarchy)
            {
                results_screen.SetActive(true);
                normalsText.text = ("" + normalHits).ToString();
                goodsText.text = ("" + goodHits).ToString();
                perfectsText.text = ("" + perfectHits).ToString();
                missesText.text = ("" + misses).ToString();
                float percentHitValue = (((goodHits + normalHits + perfectHits) / totalNotes) * 100f);
                percentHit.text = ("" + percentHitValue.ToString("F1") + "%").ToString();
                finalScoreText.text = ("" + currentScore.ToString()).ToString();

                string rankval = "F";

                if (percentHitValue >= 40f)
                {
                    rankval = "D";
                    if (percentHitValue >= 60f)
                    {
                        rankval = "C";
                        if(percentHitValue >= 70)
                        {
                            rankval = "B";
                            if (percentHitValue >= 80)
                            {
                                rankval = "A";
                                if (percentHitValue >= 90)
                                {
                                    rankval = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankval.ToString();

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
        normalHits++;
    }

    public void goodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        noteHit();
        goodHits++;
    }

    public void perfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        noteHit();
        perfectHits++;
    }

    public void noteMiss()
    {
        Debug.Log("Miss");

        currentMultiplier = 1;
        multiplerTracker = 0;
        multiplierText.text = "Multiplier: X" + currentMultiplier;
        misses++;
    }
}
