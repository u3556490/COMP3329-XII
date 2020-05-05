using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject endPanel;
    public KeyCode returnMainGameKey;
    public Text endMessage;
    public string next_scene;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (DemonMovement.hp == 0)
        {
            endMessage.text = "Congratulations!";
            endMessage.text += "\nPress [" + returnMainGameKey + "] to continue...";
            endPanel.gameObject.SetActive(true);
            if (Input.GetKeyDown(returnMainGameKey))
            {
                Debug.Log("detected enter return");
                SceneManager.LoadScene(next_scene);
            }


        }
    }
}
