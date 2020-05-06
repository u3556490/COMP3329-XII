using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint_transition : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Debug.Log("Da pacem domine");
            if (GameObject.FindGameObjectWithTag("Music") != null)
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<BGM>().StopMusic();
            }
            SceneManager.LoadScene(sceneToLoad);
        }
            
    }
}
