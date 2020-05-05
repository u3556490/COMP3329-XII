using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPshow : MonoBehaviour { 
     public Text bulletHellScoreText;
     //public static int bulletHellScore;

    // Start is called before the first frame update
    void Start()
    {
        string bulletHellScoreShow = DemonMovement.hp.ToString();
        bulletHellScoreText.text = "HP: " + bulletHellScoreShow;
    }

    // Update is called once per frame
    void Update()
    {
        string bulletHellScoreShow = DemonMovement.hp.ToString();
        bulletHellScoreText.text = "HP: " + bulletHellScoreShow;
        //Debug.Log(bulletHellScoreShow);
    }
}
