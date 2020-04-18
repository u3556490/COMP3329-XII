using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_NoteObject : MonoBehaviour
{
    public GameObject hitEffect, missEffect, goodEffect, perfectEffect;
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
                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("Hit");
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    MG_GameManager.instance.normalHit();
                } else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    MG_GameManager.instance.goodHit();
                } else
                {
                    Debug.Log("Perfect");
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    MG_GameManager.instance.perfectHit();
                }
                //MG_GameManager.instance.noteHit();
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
            if (gameObject.activeInHierarchy)
            {
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                MG_GameManager.instance.noteMiss();
            }
        }
    }
}
