﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject bullet;
    private Rigidbody2D playerRigidbody;
    private Vector3 changepos;
    //public VectorValue playerSave;
    public float speed;
    public static int life = 10;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        changepos = Vector3.zero;
        changepos.x = Input.GetAxisRaw("Horizontal");
        changepos.y = Input.GetAxisRaw("Vertical");
        MoveChar();

        if (Input.GetKeyDown("space"))
        {
            // Create a new bullet at “transform.position” which is the current position of the ship 
            Instantiate(bullet, transform.position, Quaternion.identity);
        }       
    }

    private void MoveChar()
    {
        playerRigidbody.MovePosition(
                transform.position + changepos * speed * Time.deltaTime
            );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Note(Clone)")
        {
            col.gameObject.SetActive(false);
            life -= 1;
            Debug.Log(playerControl.life);
        }
    }
}