using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Text playerLifeText;

    // Start is called before the first frame update
    void Start()
    {
        string playerLifeShow = playerControl.life.ToString();
        playerLifeText.text = "Life: " + playerLifeShow;
    }

    // Update is called once per frame
    void Update()
    {
        string playerLifeShow = playerControl.life.ToString();
        playerLifeText.text = "Life: " + playerLifeShow;
    }
}
