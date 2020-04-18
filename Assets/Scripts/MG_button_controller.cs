using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_button_controller : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite defaultImg;
    public Sprite pressedImg;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.sprite = pressedImg;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.sprite = defaultImg;
        }
    }
}
