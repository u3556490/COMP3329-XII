using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;
    public GameObject continueBtn;

    public AudioSource click;

    /**
     * https://www.youtube.com/watch?v=f-oSXg6_AMQ
     * without the animation thingy
     */

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        click.Play();
        continueBtn.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            textDisplay.text = "";
            SceneManager.LoadScene("stage_1");
        }
    }

    public void skip()
    {
        click.Play();
        continueBtn.SetActive(false);
        textDisplay.text = "";
        StopAllCoroutines();
        SceneManager.LoadScene("stage_1");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueBtn.SetActive(true);
        }
    }
}
