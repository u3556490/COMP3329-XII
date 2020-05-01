using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public AudioSource click;
    public float load_scene_wait = 0.25f;

    public void PlayGame()
    {
        StartCoroutine(loadscenedelay());
    }

    IEnumerator loadscenedelay()
    {
        click.Play();
        yield return new WaitForSeconds(load_scene_wait);
        SceneManager.LoadScene("dialog_stage1");

    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
}
