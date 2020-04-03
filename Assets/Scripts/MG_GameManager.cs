using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool startPlaying;
    public MG_BeatScroller bs;
    public static MG_GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
        Debug.Log("Hit");
    }

    public void noteMiss()
    {
        Debug.Log("Miss");
    }
}
