using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_NoteObject : MonoBehaviour
{

    public bool pressable;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (pressable)
            {
                gameObject.SetActive(false);
                MG_GameManager.instance.noteHit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            pressable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            pressable = false;
            if(gameObject.activeInHierarchy)
                MG_GameManager.instance.noteMiss();
        }
    }
}
