using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool available = false;
    public GameObject note;
    Color old;
    SpriteRenderer sr;
    public static int GM2ActivatorScoreCount=0;
    public static int GM2ActivatorComboCount = 0;
    public AudioClip drumpClip;
    public GameObject yesImage;
    public GameObject missImage;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        old = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key) && (available == false))
        {
            GM2ActivatorComboCount = 0;
            Vector2 spawnPoint = new Vector2(transform.position.x + 1.0f, transform.position.y + 0.5f);
            Instantiate(missImage, spawnPoint, Quaternion.identity);
        }
            
        if (Input.GetKeyDown(key) && (available == true))
        {
            Destroy(note.gameObject);
            GM2ActivatorComboCount++;
            AddScore();
            Vector2 spawnPoint = new Vector2(transform.position.x+1.0f, transform.position.y+0.5f);
            Instantiate(yesImage, spawnPoint, Quaternion.identity);            
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {       
        string name = obj.gameObject.name;
        if(obj.gameObject.tag == "Note")
        {
            available = true;
            note = obj.gameObject;           
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        available = false;        
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0.5f,0.5f,0.5f,1);
        yield return new WaitForSeconds(0.05f);
        AudioSource.PlayClipAtPoint(drumpClip, transform.position);
        sr.color = old;
    }

    public void AddScore()
    {
        GM2ActivatorScoreCount += getScore();
    }
    public int getScore()
    {
        if (GM2ActivatorComboCount <= 5)
            return 2 * 100;
        if (GM2ActivatorComboCount <= 8)
            return 4 * 100;
        if (GM2ActivatorComboCount <= 16)
            return 8 * 100;
        if (GM2ActivatorComboCount > 16)
            return 16 * 100;
        return 0;
    }
}
