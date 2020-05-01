using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<BGM>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
