using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM2_Note : MonoBehaviour
{
    public float beat_tempo;
    public GameObject missImage;

    // Start is called before the first frame update
    void Start()
    {
        beat_tempo = beat_tempo/60f;      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, beat_tempo * Time.deltaTime, 0f);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "BottomDestroyer")
        {
            Destroy(gameObject);
            Activator.GM2ActivatorComboCount = 0;
            Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y + 1);
            Instantiate(missImage, spawnPoint, Quaternion.identity);
        }
    }
}
