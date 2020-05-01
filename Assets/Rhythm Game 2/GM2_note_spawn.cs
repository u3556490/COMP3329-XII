using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM2_note_spawn : MonoBehaviour
{
    public GameObject note;
    public int SpawnerDropCode;

    // Start is called before the first frame update
    void Start()
    {              
    }
    

    void addNotes()
    {
        Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y);
        Instantiate(note, spawnPoint, Quaternion.identity);
    }

    void Update()
    {                 
        if (GM2_Panel_pop.gameStart)
        {           
            if ((GM_2GM.noteDropCode[SpawnerDropCode] == 2))
            {
                addNotes();
                GM_2GM.noteDropCode[SpawnerDropCode] = 1;
            }
        }      
    }
}
