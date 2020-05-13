using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deadPanel;
    public KeyCode returnMainGameKey;
    public Text gameOverMessage;
    public string next_scene;
    public Vector2 playerTargetPos;
    public VectorValue playerPos;

    // Start is called before the first frame update
    void Start()
    {
        deadPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl.life <= 0)
        {
            gameOverMessage.text = "Game Over!";
            gameOverMessage.text += "\nPress [" + returnMainGameKey + "] to continue...";
            deadPanel.gameObject.SetActive(true);
            if (Input.GetKeyDown(returnMainGameKey))
            {
                Debug.Log("detected enter return");
                playerPos.initialValue = playerTargetPos;
                SceneManager.LoadScene(next_scene);
            }
            //Time.timeScale = 0.0F;

        }
    }
}
