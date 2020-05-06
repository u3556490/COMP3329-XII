﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM2_endingText : MonoBehaviour
{
    public GameObject endPanel;
    public KeyCode returnMainGameKey;
    public Text scoresBoard;
    public string next_scene;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GM_2GM.showResult == true)
        {
            
            //Debug.Log("showresult activated");
            scoresBoard.text = "Score: " + GM_2GM.GM2score.ToString() + "\n" + "Max Combo: " + GM2_comboText.maxCombo.ToString();
            if (GM2_comboText.maxCombo <= 8)
            {
                scoresBoard.text += "\nI bet you didn't do your best...";
                
            }
            else if (GM2_comboText.maxCombo < 16)
            {
                scoresBoard.text += "\nnot bad!";
                
            }
            else if (GM2_comboText.maxCombo < 24)
            {
                scoresBoard.text += "\nGREAT!^_^";
                
            }
            else if (GM2_comboText.maxCombo >= 24)
            {
                scoresBoard.text += "\nOverPowered! (☉_☉)";
            }
            scoresBoard.text += "\nPress [" + returnMainGameKey + "] to continue...";
            endPanel.gameObject.SetActive(true);
            if (Input.GetKeyDown(returnMainGameKey))
            {
                Debug.Log("detected enter return");
                SceneManager.LoadScene(next_scene);
            }
            

        }
    }
}
