using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_talk : MonoBehaviour
{
    public string scene_to_load;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Ouch");
            // next line may be used after the dialog dk
            if (GameObject.FindGameObjectWithTag("Music") != null)
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<BGM>().StopMusic();
            }            
            SceneManager.LoadScene(scene_to_load);
        }
    }
}
