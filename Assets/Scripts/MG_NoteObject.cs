using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_NoteObject : MonoBehaviour
{

    public bool pressable = false;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && pressable)
        {
            gameObject.SetActive(false);
        }
    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            pressable = true;
        }
    }

    void onTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            pressable = false;
        }
    }
}
