using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float speed = 9f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity; 
        v.y = speed; 
        rb.velocity = v;
    }
    void OnBecameInvisible()
    { // Destroy the bullet 
        Destroy(gameObject);        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string name = col.gameObject.name;


        if (name == "Demon")
        {
            Destroy(gameObject);

            DemonMovement.hp -= 100;
            Debug.Log(DemonMovement.hp);
        }
        if (DemonMovement.hp == 0)
        {
            Destroy(col.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
