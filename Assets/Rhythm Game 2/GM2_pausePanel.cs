using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM2_pausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    public KeyCode pausePanelKey;
    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pausePanelKey) && GM2_Panel_pop.gameStart && (GM_2GM.totalTimeCount>0.1))
        {
            if (paused)
            {
                resumePanelCheck();
            }
            else
            {
                pausePanelCheck();
            }
        }

    }
    public void pausePanelCheck()
    {
            Debug.Log("sent pause request");

            paused = true;
            GM_2GM.GM2Audio.Pause();
            Time.timeScale = 0.0F;
            pausePanel.gameObject.SetActive(true);
        
    }
    public void resumePanelCheck()
    {  
            Debug.Log("sent resume request");
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1.0F;
            GM_2GM.GM2Audio.Play();
            paused = false;

    }
}

