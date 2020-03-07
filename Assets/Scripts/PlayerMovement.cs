using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 changepos;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        changepos = Vector3.zero;
        changepos.x = Input.GetAxisRaw("Horizontal");
        changepos.y = Input.GetAxisRaw("Vertical");
        if (changepos!=Vector3.zero) MoveChar();
    }

    void MoveChar()
    {
        playerRigidbody.MovePosition(
                transform.position + changepos*speed*Time.deltaTime
            );
    }
}
